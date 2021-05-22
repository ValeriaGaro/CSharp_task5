using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    class Program
    {
        static void Main()
        {
           // checking 1
            int x =  MathOperations.Sum(2, 3, 5);
           Console.WriteLine(x);

           float y = MathOperations.Sum(3.21f, 5.46f, 8.78f, 9.32f);
           Console.WriteLine(y);

           int d = MathOperations.Div(8, 4);
           Console.WriteLine(d);

           float z = MathOperations.Div(6.44f, 2.78f);
           Console.WriteLine(z);

           int e = MathOperations.Mult(5, 9);
           Console.WriteLine(e);

           float g = MathOperations.Mult(9.65f, 1.25f);
           Console.WriteLine(g);
           Console.ReadKey();
            // checking 2

            Hat new_personHat = new Hat("Blue hat", 8);
            Boots KidsBoots = new Boots("Boots for kids", 10);

            IEquipped description = new_personHat;
            description.ShowDescription();
            description = KidsBoots;
            description.ShowDescription();
            new_personHat.ShowDescription();
            KidsBoots.ShowDescription();

            //checking 3

            //different random numbers
            Random random_numbers = new Random(Environment.TickCount);
            Armor armor = new Armor(random_numbers.Next(0,5));
            Skeleton skeleton = new Skeleton(random_numbers.Next(0, 50), random_numbers.Next(0, 10), armor);
            Wolf wolf = new Wolf(random_numbers.Next(0, 50), random_numbers.Next(0, 8), random_numbers.Next(0, 100));
            
            

        }
    }

    //1
    /*
      1.  ♦ Создать класс для математических операций ♦

       Класс должен содержать следующие методы:
         • Перегруженный метод Sum, которые возвращает сумму переданных в него параметров одного типа (int или float)
        • Перегруженный метод Div, принимающий два параметра (int или float) и возвращающий результат деления первого на второе
        [Дополнительно] Определить другие математические операции
     */
    class MathOperations

    {
        static public int Sum(params int[] numbers)
        {
            int sum = 0;
            foreach (int x in numbers)

            {
                sum += x;
            }

            return sum;
        }

        static public float Sum(params float[] numbers)
        {
            float sum = 0;

            foreach (float x in numbers)

            {
                sum += x;
            }
            return sum;
        }
        static public int Div(int a, int b)
        {
            int s = a / b;

            return s;
        }

        static public float Div(float a, float b)
        {
            float s = a / b;

            return s;
        }

        static public int Mult(int a, int b)
        {
            int s = a * b;

            return s;
        }

        static public float Mult(float a, float b)
        {
            float s = a * b;

            return s;
        }
    }
    // 2

    /*
   2.  ♦ Создать интерфейс, позволяющий выводить описание одежды вне зависимости от её типа ♦

       Для этого необходимо создать:
        • Перечисление EquipType, содержащее тип одежды (торс, ноги, руки, голова)
        • Создать интерфейс IEquipped свойство типа EquipType и метод ShowDescription
       • Создать 2 любых класса для одежды (например, Hat и Boots) и реализовать в них интерфейс IEquipped
       • [По желанию] добавить индивидуальные поля или методы для классов одежды
       • Создать объекты классов одежды
       • Создать переменную тип IEquipped и с её помощью вывести на консоль описание всей созданной одежды на экран с помощью метода ShowDescription()
     */
    enum EquipType { boots, dress, hat, trousers }


    interface IEquipped
    {
        EquipType Type_of_equip { get; set; }

        void ShowDescription();

    }

    class Hat : IEquipped
    {
        string name_of;
        int quantity;

        public EquipType Type_of_equip
        {
            get => EquipType.hat; set => Type_of_equip = EquipType.hat;
        }
        public Hat(string name_of, int quantity)
        {
            this.name_of = name_of;
            this.quantity = quantity;
        }

        public void ShowDescription()
        {
            Console.WriteLine("Hat is used for head" + $"Type: {Type_of_equip}" +
                $"Name: {this.name_of}" +
                $"Quantity: {this.quantity}");
        }
    }

    class Boots : IEquipped
    {
        string name_of;
        int quantity;
        public EquipType Type_of_equip
        {
            get => EquipType.boots; set => Type_of_equip = EquipType.boots;
        }
        public Boots(string name_of, int quantity)
        {
            this.name_of = name_of;
            this.quantity = quantity;
        }

        public void ShowDescription()
        {
            Console.WriteLine("Boots is used for legs" + $"Type: {Type_of_equip}" +
                $"Name: {this.name_of}" +
                $"Quantity: {this.quantity}");
        }
    }
    //3

    /*
       3.  ♦ Битва двух монстров ♦

           Создать абстрактный класс Монстр, содержащий общие для существ поля и методы
           Свойства: 
               • Очки жизни (хп)
               • Урон
               • Доп. переменные по желанию
           Методы:
               • GetDamage (получения урона)
               • Hit (нанесение урона)

           Создать структуру Броня, содержащую:
               • Свойство или поле типа int (описывает величину урона, который будет блокироваться при каждом ударе)
               • Конструктор, позволяющий инициализировать это свойство

           Создать класс Скелет, наследуемый от класса Монстр
           В классе определить: 
               • Закрытое поле типа Armor
               • Конструктор, позволяющий инициализировать поля объекта типа Скелет (в том числе, позволяющий задать величину урона, блокируемого броней)
               • Переопределить метод получения урона так, чтобы учитывался показатель экипированной брони

           Создать класс Волк, наследуемый от класса Монстр:
               • Закрытое свойство, определяющее количество зубов у Волка (ограничить диапазон принимаемых значение от 0 до 100)
               • Конструктор, позволяющий инициализировать поля объекта типа Волк (в том числе, позволяющий задать количество зубов)
               • Переопределить метод нанесения урона так, чтобы учитывалось количество зубов

           Создать по одному объекту класса Скелет и Волк.
           Параметры, передаваемые в констуктор при создании объектов, должны генерироваться случайно при каждом запуске (использовать класс Random)
           Имитировать в коде битву между волком и скелетом до тех пор, пока у одного из них здоровье не будет меньше или равно 0
           Выводить в консоль начальные параметры монстров и лог ведения боя
    */

    abstract class Monster
    {
        abstract public int Hp
        {
            get; set;
        }
        abstract protected int Damage
        {
            get; set;
        }

        abstract public int GetDamage(int AMount_of_Damage);

        abstract public int Hit();


    }
    struct Armor
    {
        public int Damage_Value;
        public Armor(int a)
        {
            this.Damage_Value = a;

        }
    }

    class Skeleton : Monster
    {
        private int hp_monster;
        private int damage;

        public override int Hp
        {
            get => hp_monster;
            set => hp_monster = value;
            
                
        }

        protected override int Damage 
        { get => damage;

          set => damage = value;
        }

        private Armor armor;

        public Skeleton(int hp_monster, int damage_value, Armor armor)
        {
            this.Hp = hp_monster;
            this.Damage = damage_value;
            this.armor = armor;
        }
        public override int GetDamage(int AMount_of_Damage)
        {
            int DamValue = AMount_of_Damage - this.armor.Damage_Value;
            this.hp_monster -= DamValue;
            return DamValue;
        }
        public override int Hit() => damage;

    }

    class Wolf : Monster
    {
        private int hp_wolf;
        private int damage;
        private int teeth;

        public override int Hp
        {
            get => hp_wolf;
            set => hp_wolf = value;
        }
        protected override int Damage
        {
            get => damage;
            set => damage = value;
        }

        private int Teeth
        {
            set
            {
                if (value > 40)
                {
                    value = 40;
                }
                else if (value < 40)
                {
                    value = 0;
                }

                teeth = value;
            }

        }

        public Wolf(int hp_wolf, int damage_value, int teeth_value)
        {
            this.Hp = hp_wolf;
            this.Damage = damage_value;
            this.Teeth = teeth_value;
        }

        public override int GetDamage(int AMount_of_Damage)
        {
            this.hp_wolf -= AMount_of_Damage;
            return AMount_of_Damage;
        }

        public override int Hit()
        {
            damage += teeth/10;
            return damage;
        }
    }
}

