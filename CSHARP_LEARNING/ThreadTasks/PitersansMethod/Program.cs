bool in1 = true, in2 = false;
int last = 1;

void DoWork()
{
    while (true)
    {
        last = 1;
        in1 = true;
        while (in2 && last == 1)
        Thread.Sleep(500);

        //критическая секция;
        in1 = false;
        //некритическая секция;
    }
}