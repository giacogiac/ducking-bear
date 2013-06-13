using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientAdmin
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean quit = false; ;
            String menuConnec = "Connexion Menu : \n\n" + 
                                "1 - Connect\n" +
                                "2 - Quit\n";

            ImageTransfertServiceRef.ImageTransfertClient imageTransfertService = new ImageTransfertServiceRef.ImageTransfertClient();


            while (!quit)
            {
                try{
                    Console.WriteLine(menuConnec);
                    String input = Console.ReadLine();
                    int choice;
                    if (int.TryParse(input, out choice))
                    {

                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Enter your name");
                                String name = Console.ReadLine();
                                Console.WriteLine("\nEnter your password");
                                String pass = Console.ReadLine();

                                imageTransfertService.ClientCredentials.UserName.UserName = name;
                                imageTransfertService.ClientCredentials.UserName.Password = pass;


                                ImageTransfertServiceRef.UserData userInf = new ImageTransfertServiceRef.UserData();
                
                                userInf.name = name;
                                userInf.pass = pass;
                                Boolean connected = true;
                                try
                                {
                                    imageTransfertService.authentify(userInf);
                                    Console.WriteLine("you are now connected");
                                }
                                catch (Exception e)
                                {
                                    connected = false;
                                }
                             

                                if (connected)
                                {
                                    ConnectedMenu(imageTransfertService);
                                }
                                else
                                {
                                    Console.WriteLine("unknown user\n");
                                }

                                break;

                            case 2:

                                quit = true;
                                break;

                            default:
                                Console.WriteLine("Incorrect input, try again \n\n");
                                break;
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("error : " + e.Message);
                }
            }
        }


        static void ConnectedMenu(ImageTransfertServiceRef.ImageTransfertClient imageTransfertService)
        {
            String menu = "Menu \n\n" +
                        "1 - Add user\n" +
                        "2 - Delete user\n" +
                        "3 - Add album\n" +
                        "4 - Remove album\n" +
                        "5 - Add image\n" +
                        "6 - Remove image\n";

            

            Boolean disconnect = false;

            while (!disconnect)
            {
                try
                {
                    Console.WriteLine(menu);
                    String input = Console.ReadLine();
                    int choice;
                    if (int.TryParse(input, out choice))
                    {
                        ImageTransfertServiceRef.UserData data = new ImageTransfertServiceRef.UserData();
                        ImageTransfertServiceRef.ImageInfo info = new ImageTransfertServiceRef.ImageInfo();

                        switch (choice)
                        {
                            case 1:

                                Console.WriteLine("Enter the name\n");
                                data.name = Console.ReadLine();
                                Console.WriteLine("Enter the password\n");
                                data.pass = Console.ReadLine();
                                imageTransfertService.addUser(data);
                                break;

                            case 2:

                                Console.WriteLine("Enter the name\n");
                                data.name = Console.ReadLine();
                                data.pass = "";
                                imageTransfertService.addUser(data);
                                break;

                            case 3:

                                Console.WriteLine("not implemented\n");
                                break;

                            case 4:

                                Console.WriteLine("Enter name of the owner of the album\n");
                                info.userid = Console.ReadLine();
                                Console.WriteLine("Enter the name of the album to remove");
                                info.albumid = Console.ReadLine();
                                imageTransfertService.deleteAlbum(info);
                                break;

                            case 5:
                                Console.WriteLine("not implemented\n");
                                break;

                            case 6:
                                Console.WriteLine("Enter name of the owner of the album\n");
                                info.userid = Console.ReadLine();
                                Console.WriteLine("Enter the name of the album to remove");
                                info.albumid = Console.ReadLine();
                                Console.WriteLine("Enter the name of the image to remove");
                                info.imageid = Console.ReadLine();
                                imageTransfertService.deleteImage(info);
                                break;

                            default:
                                Console.WriteLine("Incorrect input, try again \n\n");
                                break;
                        }
                    }

                }
                catch (System.ServiceModel.Security.SecurityAccessDeniedException secEx)
                {
                    Console.WriteLine("your problably not an admin : \n\n" + secEx.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("error : " + e.Message);
                }
            }
        }
    }
}
