using System.Threading;



    string[] locChoice = new string[] { "двери", "столику", "картине", "вернуться" };
    string comeTo = "Подойти к..";

    //константы
    const int DOOR = 1;
    const int TABLE = 2;
    const int PICTURE = 3;
    const int DIVARICATION = 4;
    //входные
    Random rnd = new Random();

    string Pchoice = " ";//выбор локации
    int loc = DIVARICATION; //локация
    int code = rnd.Next(100, 1000); //код от сейфа
    bool door_unlocked = false;
    bool picture_down = false;
    bool safe_open = false;
    bool key_get = false;
    bool are_we_winng = false;
  
    int papernews = 0;
    int picture = 0;


    Console.WriteLine("Вы просыпаетесь в комнате.\n " +
        "\nМаленькая комната хорошо освещена одной маленькой лампочкой,\n " +
        "свисающей на хлюпеньком проводе с потолка в середине комнаты.\n" +
        "\nПридя в себя и хорошо осмотрев помещение, вы замечаете в комнате небольшой журнальный столик, \n" +
        "стоящий прямо под лампочкой, на котором кто-то оставил старую газету.\n" +
        "\nСправа от столика весит небольшая картина, \n" +
        "на которой изображен портрет человека со слегка скрюченным носом.\n" +
        "\nСзади же вас находится старая деревянная дверь, видимо, она была здесь еще со времен царя Гороха, \n" +
        "но выбить ее с ноги у вас не получится из-за нехватки сил, увы!");
    Thread.Sleep(1000);

    //основной цикл - описание и вывод доступных действий, выбор, обработка

    while (!are_we_winng)
    {

        if (loc == DIVARICATION)
        {
            Thread.Sleep(2000);
            Console.WriteLine("\nНужно придумать другое решение.. \nЧто же делать? ");
            Thread.Sleep(1000);
            Console.WriteLine("\n" + comeTo + "\n1. " + locChoice[0] + "\n2. " + locChoice[1] + "\n3. " + locChoice[2]);

            Pchoice = Console.ReadLine();
        int.TryParse(Pchoice, out loc);
        }

        else if (loc == DOOR)
        {
            Console.WriteLine("Дверь");
            if (!door_unlocked)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Дверь заперта. С этим нужно что-то сделать...");
                if (key_get == true)
                {
                Thread.Sleep(100);
                Console.WriteLine("Вы пытаетесь открыть дверь с помощью ключа..");
                    Thread.Sleep(300);
                    Console.WriteLine("...");
                    Thread.Sleep(500);
                    Console.WriteLine("Дверь открыта! Вы выбрались!");
                Thread.Sleep(700);
                are_we_winng = true;
                Console.WriteLine("Нажмите любую клавишу...");
                    Console.ReadLine();
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Возможно, где-то должен быть ключ. Нужно осмотреться.");
                    Thread.Sleep(100);
                    Console.WriteLine("\n" + comeTo + "\n1. " + locChoice[1] + "\n2. " + locChoice[2] + "\n3. " + locChoice[3]);
                    Pchoice = Console.ReadLine();
                    int.TryParse(Pchoice, out loc);
                    if (loc == 3)
                        loc++;


                }
            }

        }
        else if (loc == TABLE)
        {
            Thread.Sleep(1000);
            Console.WriteLine("\nСтолик с газетой");
            Thread.Sleep(100);
            Console.WriteLine("Поднять газету?" + "\n1. Да" + "\n2. Уйти");
            Pchoice = Console.ReadLine();
            int.TryParse(Pchoice, out papernews);
            if (papernews == 1)
            {
                Thread.Sleep(1000);
                Console.WriteLine("\nОбычная газета со статьей о каком-то розыгрыше подарков.");
                Thread.Sleep(100);
                Console.WriteLine("\nПрочитать статью?" + "\n1. Да" + "\n2. Уйти");
                Pchoice = Console.ReadLine();
                int.TryParse(Pchoice, out papernews);
                if (papernews == 1)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("\n...И главный приз получает участник под номером" + code + "...");
                    Thread.Sleep(100);
                    Console.WriteLine("...");
                    Thread.Sleep(250);
                    Console.WriteLine("Рядом с колонкой текста расположена фотография победителя со скрюченным носом и улыбкой до ушей");
                    Thread.Sleep(400);
                    Console.WriteLine("...");
                    Thread.Sleep(550);
                    Console.WriteLine("Стоит перестать обращать внимание на чужие носы. \nК слову, мужчина на фото очень сильно похож на мужчину с портрета, есть ли здесь какая-то связь?..");
                    Console.WriteLine("\n" + comeTo + "\n1. " + locChoice[0] + "\n2. " + locChoice[2] + "\n3. " + locChoice[3]);
                    Pchoice = Console.ReadLine();
                    int.TryParse(Pchoice, out loc);
                if (loc == 1)
                {
                    loc = 1;
                }
                else if (loc == 2 || loc == 3)
                    loc++;

                }
                else { loc = DIVARICATION; }
            }

            else { loc = DIVARICATION; }
        }


        else if (loc == PICTURE)
        {
            Thread.Sleep(1000);
            Console.WriteLine("\nКартина с лицом, ничего интересного.");
            Thread.Sleep(100);
            Console.WriteLine("Осмотреть картину?" + "\n1. Да" + "\n2. Уйти");
            Pchoice = Console.ReadLine();
            int.TryParse(Pchoice, out picture);
            if (picture == 1)
            {

                Thread.Sleep(1000);
                Console.WriteLine("\nОтодвинув картину в сторону, вы замечаете сейф с трехзначным кодом. ");
                Thread.Sleep(100);
                Console.WriteLine("\nПопробуете ввести код? " + "\n1. Да" + "\n2. Уйти");
                Pchoice = Console.ReadLine();
                int.TryParse(Pchoice, out picture);
                if (picture == 1)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("\nВведите код: ");
                    Pchoice = Console.ReadLine();
                    int.TryParse(Pchoice, out picture);
                    if(picture == code)
                    {
                        Thread.Sleep(100);
                        Console.WriteLine("Сейф открылся, \n" +
                            "в нем лежали какие-то документы, покрытые пылью, фотокарточка с моря и ключ от двери");
                        Thread.Sleep(200);
                        Console.WriteLine("Вы берете ключ");
                        key_get = true;
                        Thread.Sleep(1000);
                        Console.WriteLine("Осталось лишь.. ");
                        Thread.Sleep(1200);
                        Console.WriteLine("\n1. Подойти к двери ");
                        Pchoice = Console.ReadLine();
                        int.TryParse(Pchoice, out loc);
                        if (loc != 1)
                        {
                            loc = 1;
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Вы пытались, но не подошло!");
                    }
                }
                else {
                    Thread.Sleep(100);
                    Console.WriteLine("\n Нужно проявить смекалку и попробовать найти код от сейфа за картиной.");
                    Thread.Sleep(2000);
                    loc = DIVARICATION;
                }
                
            }

            else { loc = DIVARICATION; }
        }
    }
   

       