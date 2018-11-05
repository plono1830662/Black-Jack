using System;
using System.Threading;

namespace black_jack_final_version
{
    class Program
    {
        static void Main(string[] args)
        {
            int carteJ1 = 0;
            string tcarteJ1 = "";
            int carteJ2 = 0;
            string tcarteJ2 = "";
            int affcarteJ1 = 0;
            int affcarteJ2 = 0;

            affcarteJ1 = carteJ1;
            affcarteJ2 = carteJ2;


            affcarteJ1.ToString();
            affcarteJ2.ToString();


            int carteIA1 = 0;
            string tcarteIA1 = "";
            int carteIA2 = 0;
            string tcarteIA2 = "";

            int jeton = 100;
            int jetonP = 0;
            bool fin = false;
            int choix = 0;
            int totalJ = 0;
            int totalIA = 0;
            int jetonT = 0;

            string ConvertirNrbCarte(int _valeurCarte)
            {
                string rescarte = "";

                switch (_valeurCarte)
                {
                    case 1:
                        rescarte = "As";
                        break;
                    case 11:
                        rescarte = "Valet";
                        break;
                    case 12:
                        rescarte = "Dame";
                        break;
                    case 13:
                        rescarte = "Roi";
                        break;
                    default:
                        rescarte += _valeurCarte;
                        break;
                }


                return rescarte;
            }
            int ConfirmerNrbCarte(int _vraiValeurCarte)
            {
                int vraiValeur = 0;

                switch (_vraiValeurCarte)
                {
                    case 1:
                        vraiValeur = 11;
                        break;
                    case 12:
                        vraiValeur = 11;
                        break;
                    case 13:
                        vraiValeur = 11;
                        break;
                    default:
                        vraiValeur += _vraiValeurCarte;
                        break;
                }

                return vraiValeur;
            }


            string GenerateurCartetype()
            {
                string resultatTY = " ";

                Random gen = new Random();
                int type = gen.Next(1, 5);
                if (type == 1)
                {
                    resultatTY = "Pique";
                }
                else
                if (type == 2)
                {
                    resultatTY = "Coeur";
                }
                else
                if (type == 3)
                {
                    resultatTY = "Trefle";
                }
                else
                if (type == 4)
                {
                    resultatTY = "Carreau";
                }

                return resultatTY;
            }
            int GenerateurCartenrb()
            {

                Random gen = new Random();
                int nrb = gen.Next(1, 13);

                return nrb;
            }

            int JetonPerdu()
            {
                jetonT = jeton - jetonP;

                jeton = jetonT;
                return jeton;
            }



            while (fin == false)
            {
                int carteJ3 = 0;
                string tcarteJ3 = "";
                int carteIA3 = 0;
                string tcarteIA3 = "";





                Random jet = new Random();
                int jetonIA = jet.Next(1, 101);



                int JetonGagner()
                {
                    jetonT = jeton + jetonIA;

                    jeton = jetonT;
                    return jeton;
                }


                int AdditionJoueur()
                {
                    totalJ = carteJ1 + carteJ2 + carteJ3;

                    return totalJ;
                }
                int AdditionIA()
                {

                    totalIA = carteIA1 + carteIA2 + carteIA3;

                    return totalIA;
                }

                
                if (jeton > 0)
                {


                    Console.WriteLine("Vous avez " + jeton + " jetons, combien voulez vous parriez?");
                    jetonP = Convert.ToInt32(Console.ReadLine());
                    Thread.Sleep(1000);
                    Console.WriteLine("Votre adversaire parie " + jetonIA + " jetons");

                    tcarteJ1 = GenerateurCartetype();
                    carteJ1 = GenerateurCartenrb();
                    tcarteJ2 = GenerateurCartetype();
                    carteJ2 = GenerateurCartenrb();
                    string nomCarteJ1 = ConvertirNrbCarte(carteJ1);
                    string nomCarteJ2 = ConvertirNrbCarte(carteJ2);


                    Thread.Sleep(1000);


                    
                    Console.WriteLine("Vos cartes sont le " + nomCarteJ1 + " de " + tcarteJ1 + " et le " + nomCarteJ2 + " de " + tcarteJ2);

                    tcarteIA1 = GenerateurCartetype();
                    carteIA1 = GenerateurCartenrb();
                    tcarteIA2 = GenerateurCartetype();
                    carteIA2 = GenerateurCartenrb();
                    string nomCarteIA1 = ConvertirNrbCarte(carteIA1);

                    Thread.Sleep(1000);
                    
                    Console.WriteLine("Votre adversaire a " + nomCarteIA1 + " de " + tcarteIA1 + " et un autre carte");
                    Thread.Sleep(1000);
                    Console.WriteLine("Que voulez vous faire?");
                    Console.WriteLine("1- Recevoir une nouvelle carte");
                    Console.WriteLine("2- Arrêter");
                    choix = Convert.ToInt32(Console.ReadLine());

                    if (choix == 1)
                    {
                        Thread.Sleep(1000);
                        tcarteJ3 = GenerateurCartetype();
                        carteJ3 = GenerateurCartenrb();
                        string nomCarteJ3 = ConvertirNrbCarte(carteJ3);

                        Console.WriteLine("Vos cartes sont le " + nomCarteJ1 + " de " + tcarteJ1 + " ,le " + nomCarteJ2 + " de " + tcarteJ2 + " et le " + nomCarteJ3 + " de " + tcarteJ3);
                        Thread.Sleep(1000);
                        Console.WriteLine("Au tour de votre adversaire");

                        int vraiNrbCarteJ = ConfirmerNrbCarte(totalJ);
                        totalJ = AdditionJoueur();

                        int vraiNrbCarteIA = ConfirmerNrbCarte(totalIA);
                        totalIA = AdditionIA();
                        if (totalJ > totalIA)
                        {
                            carteIA3 = GenerateurCartenrb();


                            totalIA = AdditionIA();

                            Thread.Sleep(1000);
                            Console.WriteLine("Votre adversaire pige une carte");
                            Thread.Sleep(1000);
                            Console.WriteLine("Vous avez " + totalJ + " points et votre adversaire a " + totalIA + " points");

                            if (totalJ > totalIA && totalJ > 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Votre adversaire gagne vos jeton");
                                jeton = JetonPerdu();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalJ > totalIA && totalJ < 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Vous ganger les jetons de votre adversaire");
                                jeton = JetonGagner();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalIA > totalJ && totalIA > 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Vous ganger les jetons de votre adversaire");
                                jeton = JetonGagner();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalIA > totalJ && totalIA < 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Votre adversaire gagne vos jeton");
                                jeton = JetonPerdu();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalJ == totalIA)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Vous avez tous les deux le même nombre de point, vous gardez vos jetons");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalJ == 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Vous ganger les jetons de votre adversaire");
                                jeton = JetonGagner();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalIA == 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Votre adversaire gagne vos jeton");
                                jeton = JetonPerdu();
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        else if (totalJ < totalIA)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("Votre adversaire arrête");
                            Thread.Sleep(1000);
                            Console.WriteLine("Vous avez " + totalJ + " points et votre adversaire a " + totalIA + " points");

                            if (totalJ > totalIA && totalJ > 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Votre adversaire gagne vos jeton");
                                jeton = JetonPerdu();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalJ > totalIA && totalJ < 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Vous ganger les jetons de votre adversaire");
                                jeton = JetonGagner();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalIA > totalJ && totalIA > 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Vous ganger les jetons de votre adversaire");
                                jeton = JetonGagner();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalIA > totalJ && totalIA < 21)
                            {

                                Thread.Sleep(1000);
                                Console.WriteLine("Votre adversaire gagne vos jeton");
                                jeton = JetonPerdu();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalJ == totalIA)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Vous avez tous les deux le même nombre de point, vous gardez vos jetons");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalJ == 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Vous ganger les jetons de votre adversaire");
                                jeton = JetonGagner();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalIA == 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Votre adversaire gagne vos jeton");
                                jeton = JetonPerdu();
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                    }
                    else if (choix == 2)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("Au tour de votre adversaire");
                        totalJ = AdditionJoueur();
                        totalIA = AdditionIA();
                        if (totalJ > totalIA)
                        {
                            Thread.Sleep(1000);
                            carteIA3 = GenerateurCartenrb();
                            totalIA = AdditionIA();
                            Console.WriteLine("Votre adversaire pige une carte");
                            Thread.Sleep(1000);
                            Console.WriteLine("Vous avez " + totalJ + " points et votre adversaire a " + totalIA + " points");

                            if (totalJ > totalIA && totalJ > 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Votre adversaire gagne vos jeton");
                                jeton = JetonPerdu();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalJ > totalIA && totalJ < 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Vous ganger les jetons de votre adversaire");
                                jeton = JetonGagner();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalIA > totalJ && totalIA > 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Vous ganger les jetons de votre adversaire");
                                jeton = JetonGagner();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalIA > totalJ && totalIA < 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Votre adversaire gagne vos jeton");
                                jeton = JetonPerdu();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalJ == totalIA)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Vous avez tous les deux le même nombre de point, vous gardez vos jetons");
                                Console.ReadKey();
                                Console.Clear();
                            }

                            else if (totalJ == 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Vous ganger les jetons de votre adversaire");
                                jeton = JetonGagner();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalIA == 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Votre adversaire gagne vos jeton");
                                jeton = JetonPerdu();
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        else if (totalJ < totalIA)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("Votre adversaire arrête");
                            Thread.Sleep(1000);
                            Console.WriteLine("Vous avez " + totalJ + " points et votre adversaire a " + totalIA + " points");

                            if (totalJ > totalIA && totalJ > 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Votre adversaire gagne vos jeton");
                                jeton = JetonPerdu();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalJ > totalIA && totalJ < 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Vous ganger les jetons de votre adversaire");
                                jeton = JetonGagner();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalIA > totalJ && totalIA > 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Vous ganger les jetons de votre adversaire");
                                jeton = JetonGagner();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalIA > totalJ && totalIA < 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Votre adversaire gagne vos jeton");
                                jeton = JetonPerdu();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalJ == totalIA)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Vous avez tous les deux le même nombre de point, vous gardez vos jetons");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalJ == 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Vous ganger les jetons de votre adversaire");
                                jeton = JetonGagner();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (totalIA == 21)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine("Votre adversaire gagne vos jeton");
                                jeton = JetonPerdu();
                                Console.ReadKey();
                                Console.Clear();
                            }

                        }
                    }

                }
                else if (jeton <= 0)
                {
                    Console.WriteLine("Vous n'avez plus de point, vous devez arrêter");
                    fin = true;
                }
            }


            Console.ReadKey();
        }
    }
}
