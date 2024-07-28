using System.ComponentModel;

//var d = 1;
//Func<Object, ArgumentException> fn1 = null;
//Func<string, ArgumentException> fn2 = fn1;

Test1<object> test1 = null;
Test1<string> test1_2 = test1;

Test2<string> test2 = null;
Test2<object> test2_2 = test2;


public delegate MaskedTextResultHint Func<in T, out TResult>(T arg);

public delegate int Test1<in T>(T arg);

public delegate TResult Test2<out TResult>(int arg);