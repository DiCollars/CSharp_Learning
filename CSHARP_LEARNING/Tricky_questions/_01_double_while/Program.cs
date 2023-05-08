//Is cicle endless? If yes, why and how can we fix it?
double val = 1.0;
int iteration = 1;

while(val != 0)
{
    Console.WriteLine($"iteration: {iteration}; val: {val}");

    val = val - 0.1;
    iteration++;

    Thread.Sleep(1000);
}