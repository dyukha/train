 // open - ����������� ������� � ����������� ���� ��� ������������� ������������ � ���
 //    ��������, ������� � ������ �������.
 open System.Windows.Forms // - ������ Form (����), Button (������)� �.�.
 // Beep - �������� ������
 let beep _ = System.Console.Beep()
 // �������� ���� � ����������� ������ ���� !���������� �������� �����-������� ����������� - � ������� Application.Run(����)!
 // Visible - ��������� ��������, �������� �� ���� �������
 // TopMost - ���� �� �������� ���� � ���������(true-false) (���������� ���� � ���������� ��������� � �������� ������� ������)
 // Text - ����� ��������� ����
 let window = new Form(Visible=true,TopMost=true,Text="",
                       Top = 0, Left = 0, Height = 512, Width = 768) // ������ ����=768
 window.WindowState <- FormWindowState.Normal // ���������� (,�������� ,����������) ����. ������ ��� ������� �� ������� � �����������
 window.ClientSizeChanged.Add beep
 window.KeyDown.Add beep
 window.KeyPress.Add beep
 window.KeyUp.Add beep
 Application.Run window // ����������� ����
