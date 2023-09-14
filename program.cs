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
    for(int klizma = 0; klizma < h.Length; klizma++)
    {
        if(klizma%4 ==0) Console.Write("\n");
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

byte checkr(byte[] num,byte jopa,byte i)
{
    byte tmp = 255;
    for (byte m = 0; m < num.Length; m++)
    {
        if (num[m] == jopa && m!=i) { tmp = m; }
    }
    return tmp;
}
byte samokat(byte[] num,byte rezaud)
{       
    byte r = 0;
    rezaud = 0;
    Random mel = new Random();
    for (byte po = 0; po < num.Length; po++)
    {
        if ((r = checkr(num, num[po], po)) != 255) { num[r] = Convert.ToByte(mel.Next(16));rezaud++; }

    }
  
    //if(rezaud>0) samokat(num, 0);  
    return rezaud;
}

byte find(byte[] num, byte ru)
{
    byte tmp = 255;
    for (byte gh = 0; gh<num.Length;gh++)
    {
        if (num[gh]==ru)
        {
            tmp = gh;
            break;
        }
    }
    return tmp;
}
byte move(byte[] num, char yo,byte oy)
{
    byte lol = 0;
    switch (yo)
    {
        case 'u':
            lol = find(num,oy);
            p(num[lol],num[lol-4],num);
            break;
        case 'd':
            lol = find(num, oy);
            p(num[lol], num[lol + 4], num);
            break;
        case 'l':
            lol = find(num, oy);
            p(num[lol], num[lol - 1], num);
            break;
        case 'r':
            lol = find(num, oy);
            p(num[lol], num[lol + 1], num);
            break;

    }







    return 0;





}







byte[] num = new byte[16];
kazino(num);
bool pisa = true;
while (pisa)
{
    //Console.WriteLine(pisa);
    if(samokat(num,0)==0) { pisa = false; break;}
}
p(num[15],0,num);

char sad = '0';
byte kl = 0;
spirit(num);
while (sad != 'q')
{
    
    
    
    kl= Convert.ToByte(Console.ReadLine());
    sad = Convert.ToChar(Console.ReadLine());
    move(num, sad,kl);
    spirit(num);
}

//while (true)
//{
//    p(Convert.ToByte(Console.ReadLine()), Convert.ToByte(Console.ReadLine()), num);
//    Console.WriteLine();
//    spirit(num);
//}



//for (int y = 0; y < num.Length; y++)
//{
//    Console.Write(num[y] + " ");
//}

//p(2, 4, num);




