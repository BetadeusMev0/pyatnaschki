
bool check_win(byte[] num) 
{
    for (int i = 0; i < num.Length; i++) 
    {
        if (num[i] != i+1) return false;
    }
    return true;
}

bool check_zero(byte[] num, byte first, byte second) 
{
    if (first + 4 == second) return true;
    if (first - 4 == second) return true;
    if (first - 1 == second && first / 4 == second / 4) return true;
    if (first + 1 == second && first / 4 == second / 4) return true;

    return false;
}

void p(byte g, byte a, byte[] mama)
{
    for (int l = 0; l < mama.Length; l++)
    {
        if (mama[l] == g)
        {
            mama[l] = a;
            continue;
        }

        if (mama[l] == a)
        {
            mama[l] = g;
        }
    }

}

void spirit(byte[] h)
{
    for (int klizma = 0; klizma < h.Length; klizma++)
    {
        if (klizma % 4 == 0 && klizma != 0) Console.Write("\n");
        Console.Write(h[klizma] + " ");
    }
    Console.WriteLine();


}

void kazino(byte[] num)
{

    Random melstroy = new Random(100);

    for (int lisina = 0; lisina < num.Length; lisina++)
    {
        num[lisina] = Convert.ToByte(melstroy.Next(16));
    }


}

byte checkr(byte[] num, byte s, byte i)
{
    byte tmp = 255;
    for (byte m = 0; m < num.Length; m++)
    {
        if (num[m] == s && m != i) { tmp = m; }
    }
    return tmp;
}
byte samokat(byte[] num, byte rezaud)
{
    byte r = 0;
    rezaud = 0;
    Random mel = new Random();
    for (byte po = 0; po < num.Length; po++)
    {
        if ((r = checkr(num, num[po], po)) != 255) { num[r] = Convert.ToByte(mel.Next(16)); rezaud++; }

    }

    return rezaud;
}

byte find(byte[] num, byte ru)
{
    byte tmp = 255;
    for (byte gh = 0; gh < num.Length; gh++)
    {
        if (num[gh] == ru)
        {
            tmp = gh;
            break;
        }
    }
    return tmp;
}
byte move(byte[] num, char yo, byte oy)
{
    byte lol = find(num, oy);
    byte tmp = find(num, 0);
    byte err = 0;
    if (check_zero(num, lol, tmp)) p(num[lol], num[tmp], num);
    else err++;  



    //switch (yo)
    //{
    //    case 'u':
    //        tmp = lol - 4;
    //        if (tmp >= 0 && num[tmp] == 0) p(num[lol], num[tmp], num);
    //        else err++;
    //        break;
    //    case 'd':
    //        tmp = lol + 4;
    //        if (tmp < 16 && num[tmp] == 0) p(num[lol], num[tmp], num);
    //        else err++;
    //        break;
    //    case 'l':
    //        tmp = lol - 1;
    //        if (tmp < 16 && tmp >=0 && tmp / 4 == lol / 4 && num[tmp] == 0)  p(num[lol], num[tmp], num);
    //        else err++;
    //        break;
    //    case 'r':
    //        tmp = lol + 1;
    //        if (tmp < 16 && tmp >= 0 && tmp / 4 == lol / 4 && num[tmp] == 0)  p(num[lol], num[tmp], num);
    //        else err++;
    //        break;
    //}
    return err;
}

Console.Write("Игра пятнашки: \n");
byte[] num = new byte[16];
kazino(num);
bool pi = true;
while (pi)
{
    if (samokat(num, 0) == 0) { pi = false; break; }
}
p(num[15], 0, num);
byte err = 0;
string tmp = "0";
char sad = '0';
byte kl = 0;
spirit(num);
Console.WriteLine("Как играть: \nЦель: необходимо передвинуть элементы таким образом что бы все цифры были по порядку\nУправление: \n0 - сиволизирует пустую ячейку куда можно двигать элементы \nВведите число для сдвига в сторону пустой ячейки\nq - закончить игру\nВ случае неверного хода будет выведено n/a\nGood luck! Have fun!");
while (sad != 'q')
{
    try {
        if ((tmp = Console.ReadLine()) != "q") kl = Convert.ToByte(tmp);
        else  sad = Convert.ToChar(tmp);
    }
    catch { Console.WriteLine("n/a"); err++; }
    finally { 
    if (err == 0 && move(num, sad, kl) != 0) Console.WriteLine("n/a");
    if (err == 0 && sad != 'q') spirit(num);
        err = 0;
    }
    if (err == 0 && check_win(num)) { sad = 'q'; Console.Write("\nВы выйграли!\nСпасибо за игру!"); }
}
