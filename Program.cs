namespace binaryTree
{
    internal class Program
    {
        public static void Main()
        {
            bool isNameEmpty = false;
            CreateEmployeeTree(isNameEmpty);
        }

        public static void CreateEmployeeTree(bool isEmployeeNameEmpty)
        {
            isEmployeeNameEmpty = false;
            var binaryTree = new BinaryTree<(string, int)>();
            while (isEmployeeNameEmpty == false)
            {
                string? employeeName;
                int employeeSalary;
                Console.WriteLine("Введите имя сотрудника:");
                employeeName = Console.ReadLine();
                if (employeeName == "")
                {
                    isEmployeeNameEmpty = true;
                    break;
                }
                Console.WriteLine("Введите зарплату сотрудника:");
                employeeSalary = Int32.Parse(Console.ReadLine());
                binaryTree.Add((employeeName, employeeSalary));
            }
            binaryTree.InOrderTraversal(binaryTree.RootNode, (name, value) => Console.WriteLine($"{name} - {value}"));
            FindEmployeeNameBySalary(binaryTree, isEmployeeNameEmpty);
        }
            
        public static void FindEmployeeNameBySalary(BinaryTree<(string, int)> tree, bool isEmployeeNameEmpty)
        {
            Console.WriteLine("Введите зарплату для поиска сотрудника: ");
            var findingSalary = Int32.Parse(Console.ReadLine());
            var employeeResult = tree.FindNode(findingSalary) != null ? tree.FindNode(findingSalary).Data.Item1 : "Такой сотрудник не найден";
            Console.WriteLine(employeeResult);
            Commander(isEmployeeNameEmpty, tree);
        }
        public static void Commander(bool isEmployeeNameEmpty, BinaryTree<(string, int)> tree)
        {
            Console.WriteLine("Введите команду для продолжения:");
            Console.WriteLine("0 - переход к началу программы и генерация нового дерева сотрудников");
            Console.WriteLine("1 - поиск сотрудников в текущем дереве");
            var consoleCommandInt = Int32.Parse(Console.ReadLine());
            
            switch (consoleCommandInt)
            {
                case 0:
                    CreateEmployeeTree(isEmployeeNameEmpty);
                    break;
                case 1:
                    FindEmployeeNameBySalary(tree, isEmployeeNameEmpty);
                    break;
                default:
                    Commander(isEmployeeNameEmpty, tree);
                    break;
            }
        }
    }
}