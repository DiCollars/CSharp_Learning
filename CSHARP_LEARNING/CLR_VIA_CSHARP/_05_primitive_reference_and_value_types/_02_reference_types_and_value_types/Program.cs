//* new - returns memory address of allocated object
//All references-types inherited from Object, all value-types inherited from System.ValueType, example:
//Reference-type Object => String
//Value-types Object => ValueType => Int32
//Also, value types can impliment interfaces

static void ValueTypeDemo()
{
    SomeRef r1 = new SomeRef(); // Allocated in heap
    SomeVal v1 = new SomeVal(); // Allocated on stack

    r1.x = 5; // Pointer dereference
    v1.x = 5; // Changed on stack
    Console.WriteLine(r1.x); // Displays "5"
    Console.WriteLine(v1.x); // Also displays "5"

    SomeRef r2 = r1; // Copies reference (pointer) only
    SomeVal v2 = v1; // Allocate on stack & copies members
    r1.x = 8; // Changes r1.x and r2.x
    v1.x = 9; // Changes v1.x, not v2.x
    Console.WriteLine(r1.x); // Displays "8"
    Console.WriteLine(r2.x); // Displays "8"
    Console.WriteLine(v1.x); // Displays "9"
    Console.WriteLine(v2.x); // Displays "5"
}

ValueTypeDemo();

// Reference type (because of 'class')
class SomeRef { public Int32 x; }
// Value type (because of 'struct')
struct SomeVal { public Int32 x; }

//When you should use value-types instead of reference-types:
//1. When your type have no state-changing methods (immutable) - recomended rule
//      - is to mark all instances-fields as readonly.
//2. The type doesn't need to inherit from any types.
//3. Type won't have any types derived from it.
//4. Small instance - size less then 16 bytes OR will never be used as method argument

//Value-types and reference-types differ:
//1. Value-types can be in unboxed\boxed form, reference-types always in boxed form.
//2. Value-types can't be abstract, cos it is implicitly sealed. No virtual methods.
//3. Value-types contains memory address of objects - when it created, default value
//      initialized by null - attempting to use it will drive to NullReferenceException,
//      in the other side - value-type initialized by 0 by default - so, you can't get
//      the NullReferenceException - but you have to initialize all fields before invoke
//      any methods
//4. Because unboxed value types aren’t allocated on the heap, the storage allocated for them is
//      freed as soon as the method that defines an instance of the type is no longer active as opposed
//      to waiting for a garbage collection. 

//The compiler can change the order of fields in your object to improve performance. If it's not ok -
//you can use System.Runtime.InteropServices.StructLayoutAttribute attribute - and in the .ctor set 
//option - Sequential, Explicit, Auto. By default it is Auto.

//You can't use ValueType directly for creating value-type - should use struct
//public sealed class SuperValueType : ValueType
//{
//    public SuperValueType()
//    {
//    }
//}