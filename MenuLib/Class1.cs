namespace MenuLib
{
    public class MenuLibMain
    {
        public class MenuItem
        {
            public required string Option { get; set; }
            public IEnumerable<MenuItem>? SubMenu { get; set; }
        }


        public static MenuItem? GetSelection(string title, IEnumerable<MenuItem> items)
        {

            if (items == null)
                return null;
            int len = items.Count() - 1;
            var backGround = Console.BackgroundColor;
            var foreGround = Console.ForegroundColor;
            int pos = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(title + "\n\n---");

                int tmpnum = -1;
                foreach (var item in items)
                {
                    tmpnum++;
                    if (pos != tmpnum)
                    {
                        Console.WriteLine($"{tmpnum + 1}) {item.Option}\n---");
                        continue;
                    }
                    Console.BackgroundColor = foreGround;
                    Console.ForegroundColor = backGround;
                    backGround = Console.ForegroundColor;
                    Console.WriteLine($"{tmpnum + 1}) {item.Option}");
                    Console.ForegroundColor = foreGround;
                    Console.BackgroundColor = backGround;
                    Console.WriteLine("---");
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:

                        if (pos >= len)
                            pos = 0;
                        else
                            pos++;
                        break;
                    case ConsoleKey.UpArrow:

                        if (pos <= 0)
                            pos = len;
                        else
                            pos--;
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.Enter:
                        var item = items.Skip(pos).Take(1).First();
                        if (item.SubMenu != null)
                            return GetSelection(title, item.SubMenu);
                        return item;
                }

            }
        }

    }
}
