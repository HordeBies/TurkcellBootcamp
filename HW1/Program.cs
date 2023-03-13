int[] bucket = { 1, 2, 3, 4, 5 };

if(bucket.Length == 0)
    return;

int min, max, sum, avg;

void Reset()
{
    min = int.MaxValue;
    max = int.MinValue;
    sum = 0;
}

void Print(string prefix) => Console.WriteLine($"{prefix}:\n\tmin={min}\tmax={max}\tsum={sum}\tavg={avg}");

#region For
Reset();
for (int i = 0; i < bucket.Length; i++)
{
    var item = bucket[i];
    if(item < min) min = item;
    if(item > max) max = item;
    sum += item;
}
avg = sum / bucket.Length;
Print("For");
#endregion

#region For Each
Reset();
foreach (var item in bucket)
{
    if(item < min) min = item;
    if(item > max) max = item;
    sum += item;
}
avg = sum / bucket.Length;
Print("For each");
#endregion

#region While
Reset();
var idx = 0;
while (idx < bucket.Length)
{
    var item = bucket[idx];
    if (item < min) min = item;
    if (item > max) max = item;
    sum += item;
    idx++;
}
avg = sum /bucket.Length;
Print("While");
#endregion

#region Do While
Reset();
idx = 0;
do
{
    var item = bucket[idx];
    if (item < min) min = item;
    if (item > max) max = item;
    sum += item;
    idx++;
}while(idx < bucket.Length);
avg = sum / bucket.Length;
Print("Do while");
#endregion