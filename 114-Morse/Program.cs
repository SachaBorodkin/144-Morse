using System;
using System.Collections.Generic;
namespace morse
{
    class Program
    {
        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }


        public static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }

        public static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }


       


        
   
        static Dictionary<char, string> morseCode = new Dictionary<char, string>()

            {

                { 'A', ".-" }, { 'B', "-..." }, { 'C', "-.-." }, { 'D', "-.." },

                { 'E', "." }, { 'F', "..-." }, { 'G', "--." }, { 'H', "...." },

                { 'I', ".." }, { 'J', ".---" }, { 'K', "-.-" }, { 'L', ".-.." },

                { 'M', "--" }, { 'N', "-." }, { 'O', "---" }, { 'P', ".--." },

                { 'Q', "--.-" }, { 'R', ".-." }, { 'S', "..." }, { 'T', "-" },

                { 'U', "..-" }, { 'V', "...-" }, { 'W', ".--" }, { 'X', "-..-" },

                { 'Y', "-.--" }, { 'Z', "--.." },

                { '1', ".----" }, { '2', "..---" }, { '3', "...--" }, { '4', "....-" },

                { '5', "....." }, { '6', "-...." }, { '7', "--..." }, { '8', "---.." },

                { '9', "----." }, { '0', "-----" }, {' ', "/"}


            };
        static void Main(string[] args)
        {
            
            int choix1 = 0;
            int choix2 = 0;
            int nombre = 0;
     
            Console.WriteLine("=== Couteau Suisse – Utilitaires ===");
            Console.WriteLine("1. Convertir du texte en code Morse");
            Console.WriteLine("2. Convertir des nombres entre différentes bases (Décimal <> Binaire <> Octal)");
            Console.WriteLine("3. Chiffre Caesar");
            Console.Write("\nVeuillez entrer votre choix : ");
            try
            {
                choix1 = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("veuillez ecrire un nombre");
                throw new ArgumentException("Parameter cannot be string", nameof(choix1));
            }
            if (choix1 > 3 || choix1 <= 0)
            {
                Console.WriteLine("veuillez ecrire un nombre entre 1 et 2");
                throw new ArgumentException("Parameter cannot be less than 1 or bigger than 2", nameof(choix1));
            }
            else if (choix1 == 1)
            {
                Console.WriteLine("==Phrase en morse==");
                Console.WriteLine("By TolikDevStudio\n");
                Console.Write("Ecrivez une phrase : ");
                string text = Console.ReadLine().ToUpper();

                string result = "";
                foreach (char l in text)
                {
                    if (morseCode.ContainsKey(l))
                    {
                        result += morseCode[l] + " ";
                    }
                    else
                    {
                        result += " ";
                    }

                }
                Console.WriteLine("Résultat : " + result);
            }
            else if (choix1 == 2)
            {
                Console.WriteLine("=== Convertisseur de bases ===");
                Console.WriteLine("1. Décimal > Binaire");
                Console.WriteLine("2. Binaire > Décimal");
                Console.WriteLine("3. Binaire > Octal");
                Console.WriteLine("4. Octal > Binaire");

                Console.Write("\nVeuillez entrer votre choix : ");
                try
                {
                    choix2 = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("veuillez ecrire un nombre");
                    throw new ArgumentException("Parameter cannot be string", nameof(choix2));
                }
                if (choix2 > 4 || choix2 <= 0)
                {
                    Console.WriteLine("veuillez ecrire un nombre entre 1 et 2");
                    throw new ArgumentException("Parameter cannot be less than 1 or bigger than 4", nameof(choix2));
                }
                else if (choix2 == 1)
                {
                    Console.Write("\nVeuillez entrer votre  nombre décimal : ");
                    try
                    {
                        nombre = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("veuillez ecrire un nombre");
                        throw new ArgumentException("Parameter cannot be string", nameof(nombre));
                    }
                    string result = "";
                    for (int i = 0; i < 10000; i++)
                    {
                        if (nombre % 2 == 0)
                        {
                            nombre /= 2;
                            result += "0";
                        }
                        else
                        {
                            nombre -= 1;
                            nombre /= 2;
                            result += "1";
                        }
                        if (nombre == 1)
                        {
                            break;
                        }
                    }
                    char[] charArray = result.ToCharArray();
                    Array.Reverse(charArray);
                    string bonresult = new string(charArray);
                    Console.WriteLine("Résultat : " + bonresult);
                }
                else if (choix2 == 2)
                {
                    string binaire = "";
                    Console.Write("\nVeuillez entrer votre  nombre binaire : ");

                    binaire = Console.ReadLine();
                    string allowed = "10";
                    int dedecimal = 0;
                    char[] charArray = binaire.ToCharArray();
                    Array.Reverse(charArray);
                    string bonbinaire = new string(charArray);
                    double jsp = 0;

                    foreach (char c in binaire)
                    {

                        if (!allowed.Contains(c))
                        {
                            break;
                            throw new ArgumentException("Le nombre n'est pas binaire, ftg", nameof(binaire));
                        }
                    }
                    char[] array = binaire.ToCharArray();
                    Array.Reverse(array);

                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] == '1')
                        {
                            if (i == 0)
                            {
                                dedecimal += 1;
                            }
                            else
                            {
                                dedecimal += (int)Math.Pow(2, i);
                            }
                        }

                    }
                    Console.WriteLine("Résultat : " + dedecimal);

                }
                else if (choix2 == 3)
                {
                    int n1, n, p = 1;
                    int dec = 0, i = 1, j, d;
                    int ocno = 0;
                    Console.Write("\nVeuillez entrer votre nombre binaire : ");
                    n = Convert.ToInt32(Console.ReadLine());
                    n1 = n;

                    for (j = n; j > 0; j = j / 10)
                    {
                        d = j % 10;
                        if (i == 1)
                            p = p * 1;
                        else
                            p = p * 2;

                        dec = dec + (d * p);
                        i++;
                    }

                    i = 1;
                    for (j = dec; j > 0; j = j / 8)
                    {
                        ocno = ocno + (j % 8) * i;
                        i = i * 10;
                        n = n / 8;
                    }
                    Console.WriteLine("Résultat : " + ocno);
                }
                else if (choix2 == 4)
                {
                    {
                        string octal = "";
                        Console.Write("\nVeuillez entrer votre  nombre octal : ");
                        octal = Console.ReadLine();
                        int i = 0;
                        string binary = "";
                        while (i < octal.Length)
                        {
                            char c = octal[i];
                            switch (c)
                            {
                                case '0':
                                    binary += "000";
                                    break;
                                case '1':
                                    binary += "001";
                                    break;
                                case '2':
                                    binary += "010";
                                    break;
                                case '3':
                                    binary += "011";
                                    break;
                                case '4':
                                    binary += "100";
                                    break;
                                case '5':
                                    binary += "101";
                                    break;
                                case '6':
                                    binary += "110";
                                    break;
                                case '7':
                                    binary += "111";
                                    break;
                                default:
                                    System.Console.WriteLine("\noctal non valide, insérez le billet de 20 Frs pour continuer " + octal[i]);
                                    break;
                            }
                            i++;
                        }
                        Console.WriteLine("Résultat : " + binary);
                    }

                }
            }
            else if (choix1 == 3) {

                Console.WriteLine("Scribe seriem litterarum ad encryptandum:");
                string UserString = Console.ReadLine();

                Console.WriteLine("\n");

                Console.Write("Clavem tuam inscribe : ");
                int key = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");


                Console.WriteLine("Data Encryptata");

                string cipherText = Encipher(UserString, key);
                Console.WriteLine(cipherText);
                Console.Write("\n");

                Console.WriteLine("Data Decrypta:");

                string t = Decipher(cipherText, key);
                Console.WriteLine(t);
                Console.Write("\n");




                Console.ReadKey();
            }
        }
    }
}