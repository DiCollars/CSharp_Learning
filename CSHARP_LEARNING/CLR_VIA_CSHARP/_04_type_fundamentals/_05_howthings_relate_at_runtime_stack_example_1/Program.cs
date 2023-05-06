//application (usually) has one process - one process has many threads - when a thread is created, it is allocated a 1-MB stack
//first step is process starting and creating main thread and have been allocated stack (for local var & refferencies to heap)
//stack is filling from end to start

var Method_2 = (string n) =>
{
    //3.
    int lenght = n.Length;
    int tally;

    //4.
    Console.WriteLine(n);
    Console.WriteLine(lenght);
};

var Method_1 = () =>
{
    //1.
    string name = "Joe";
    //2.
    Method_2(name);
    //5.
};

Method_1();

//What exactly happend?

//1. It allocate memory in stack for a local variable 'name'
//███████████████████████████████
//█             STACK           █
//███████████████████████████████
//█   Main[returning adress]    █
//█       name (string)         █
//█                             █
//█                             █
//█                             █
//█                             █
//█                             █
//█                             █
//███████████████████████████████

//2. Method_1 calls Method_2 passing variable 'name' as 'n' argument and pass 'returning adress' - for returning from method
//███████████████████████████████
//█             STACK           █
//███████████████████████████████
//█   Main[returning adress]    █
//█       name (string)         █ // actually - name and n are the links for one item in heap - "Joe"
//█        n (string)           █
//█ Method_1[returning adress]  █
//█                             █
//█                             █
//█                             █
//█                             █
//███████████████████████████████

//3. Method_2 allocate memory for lenght and tally in stack
//███████████████████████████████
//█             STACK           █
//███████████████████████████████
//█   Main[returning adress]    █
//█       name (string)         █
//█        n (string)           █
//█ Method_1[returning adress]  █
//█       tally (int)           █
//█      lenght (int)           █
//█                             █
//█                             █
//███████████████████████████████ 

//4. Method_2s code executes and returns at 'returning adress'
//███████████████████████████████
//█             STACK           █
//███████████████████████████████
//█   Main[returning adress]    █
//█       name (string)         █
//█                             █
//█                             █
//█                             █
//█                             █
//█                             █
//█                             █
//███████████████████████████████

//5. Method_1 returns at 'returning adress'
//███████████████████████████████
//█             STACK           █
//███████████████████████████████
//█                             █
//█                             █
//█                             █
//█                             █
//█                             █
//█                             █
//█                             █
//█                             █
//███████████████████████████████