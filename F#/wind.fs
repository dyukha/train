 // open - подключение модулей и пространств имен для использования содержащихся в них
 //    значений, классов и других модулей.
 open System.Windows.Forms // - классы Form (окно), Button (кнопка)и т.д.
 // Beep - звуковой сигнал
 let beep _ = System.Console.Beep()
 // создание окна с программным именем окно !необходимо вызывать слово-функцию отображения - к примеру Application.Run(окно)!
 // Visible - булевское значение, является ли окно видимым
 // TopMost - окно на передний план в программе(true-false) (очерёдность окон с одинаковым значением в обратном порядке вызова)
 // Text - текст заголовка окна
 let window = new Form(Visible=true,TopMost=true,Text="",
                       Top = 0, Left = 0, Height = 512, Width = 768) // Ширина окна=768
 window.WindowState <- FormWindowState.Normal // Нормальное (,Свёрнутое ,Развёрнутое) окно. Просто для примера не внесено в конструктор
 window.ClientSizeChanged.Add beep
 window.KeyDown.Add beep
 window.KeyPress.Add beep
 window.KeyUp.Add beep
 Application.Run window // отображение окна
