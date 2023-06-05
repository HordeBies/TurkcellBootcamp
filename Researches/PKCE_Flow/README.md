# PKCE in .Net Identity
PKCE stands for Proof Key for Code Exchange. It is an extension to the OAuth 2.0 authorization framework that provides an additional layer of security for mobile and native applications during the authorization code flow.

### OAuth
OAuth 2.0 is a widely used protocol for granting access to resources on behalf of a user without sharing their credentials. The authorization code flow is one of the grant types in OAuth 2.0, typically used for server-side web applications. However, it presents some security challenges for mobile and native applications.

### Assumptions
- You have basic understanding of how .Net Identity works
    - And familiar with Identity Scaffolding in .Net
- You have basic understanding of how OAuth works 

# Why

Like mentioned before, PKCE is used to add an additional layer of protection to OAuth 2.0 authorization. But why?
Imagine a user named **bies** have 2 applications on your device, lets call them app1 and app2. And developers created app1 using OAuth 2 authorization code flow, which is good but they hadn't realized there are some vulnerabilities discovered in native apps. Now lets follow this made up scenario:

- app1 wants to make a network call to the service provider so it calls over network services and it makes a request
    - app1: -calls to network services- "can i get my authorization code"
    - network services: "sure"
    (There is just one problem. Network services is a little too noisy. Its leaking the requests and responses in the Operation System Logs.)
    - network services: -goes to the /authorize endpoint- "can i have bies' authorization code"
    (Endpoint complies with the request and sends the authorization code for bies to network services)
    - network services: -goes to app1- "here you go, your auth code is: **orange**"
    (Unfortunately, because network services is a little too noisy, the second app hears the authorization code as well)
- app2 is maliciously trying to acces bies' account using app1
    - app2: -calls to network services- "can i get bies' keys?"
    - network services: "whats the auth code?"
    - app2: -using the leaked OS logs- "**orange**"
    - network services: -goes to the /token endpoint- "i need bies' keys"
    - endpoint: "well, what is the auth code?"
    - network services: "**oranges**"
    (Endpoint again complies with the request and sends the bies' keys to app2)
 
As you can see app2 maliciously grab our auth token and use it without our consent. So we need a way to protect it. One way is using PKCE to prove that the auth token came from a trusted app.

# How
![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/281293a2-130b-41a6-a87a-ba05ae4766f9)

Imagine the following OAuth2 flow with PKCE (bold parts implies PKCE flow)
- User tries to login to Application
- **Application generates a Code Verifier**
- **Application encrypts Code Verifier (in this example with SHA256 hashing algorithm) and save as Code Challenge**
- Application HTTP Redirects the user **with Code Challenge** to Identity Provider
- The Authorization Server then **persists that Code Challenge temporarily and** returns the user back to the application with authorization code
- Once the application gets the Auth Code, it sends the Auth Code **with Code Verifier** in an HTTP POST back to the identity provider
- Once the identity provider receive the POST request with Auth Code **and Code Verifier it will perform the same encryption as application used (SHA256 in this example) and it will compare it to original Code Challenge . If the two hashes match then** Identity Provider will return the access token back to the application.
- Now application is free to use the access token and access any resources on behalf of the user.

# Code

So how do we implement PKCE to our .Net project. It is fairly simple. For that i prefer to start with a MVC project with Individual accounts as Identity

![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/f93596c8-4107-402e-ab82-cf62b37c059f)

Then go ahead and add google external authentication with OAuth. For that you can follow this guide: [Microsoft Documentation for External Login using Google](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-7.0)

After adding Google using OAuth, we can tweak the Program.cs to force using PKCE for us:

```cs
builder.Services.AddAuthentication()
    .AddGoogle("google", options =>
    {
        // You can get the clientid and client secret from the google cloud console then secure them with user secrets
        options.ClientId = builder.Configuration["ClientId"];
        options.ClientSecret = builder.Configuration["ClientSecret"];

        options.UsePkce = true;
    });
```

And we are done, now .Net is using PKCE to secure our auth key and our identity.
