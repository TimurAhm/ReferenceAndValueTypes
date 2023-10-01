internal class Program
{
    private static void Main(string[] args)
    {
        SomeReferenece r1 = new SomeReferenece(); //Размещается в куче
        SomeValue v1 = new SomeValue(); // размещается в стеке

        r1.x = 6;
        v1.x = 3;

        Console.WriteLine($"r1 - {r1.x}, v1 - {v1.x}"); 
        // r1 - 6, v1 - 3
        // r1 - имеет помещен в кучу а в стеке только ссылка, v1 - помещен в стек 
        
        SomeReferenece r2 = r1;
        SomeValue v2 = v1;
        
        r2.x = 666;
        v2.x = 333;

        Console.WriteLine($"r1 - {r1.x}, v1 - {v1.x}"); 
        /* r1 - 666, v1 - 3 .
         * Я вывожу тоже самое, что и в предыдущий раз, не меняв их значения, но одно изменилось
         * все дело в том, где они размещены
         * 
         * при изменении значения ссылочного типа (r1 и r2) меняется их значение в куче, на которое ссылаются и r1, и r2,
         * следовательно изменив его, они оба будут иметь это одинаковое значение, тк при SomeReference("class" см 38 строку) r2 = r1 копируется только ссылка
         * 
         * при изменении значние значимого типа (v1 и v2) меняется их значения в стеке, они не ссылаются на кучу,
         * тк при SomeValue("struct" см 40 строку) v2 = v1, в стек помещается v2 и копируется члены v1
         */

        Console.WriteLine($"r1 - {r2.x}, v1 - {v2.x}"); // r1 - 666, v1 - 333

    }
}

class SomeReferenece { public Int32 x; } //Ссылочный тип т.к. class

struct SomeValue { public Int32 x; } // Значимый тип т.к. struct

