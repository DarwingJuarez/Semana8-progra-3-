internal class Program
{
    private static void Main(string[] args)
    {
        //declaramos variables
        double opcl = 0, comprobacion = 0;
        decimal[] precio;
        decimal[] total_producto;
        decimal total = 0, subtotal = 0, monto_pago = 0, cambio = 0, descuento = 0;
        double cantidad = 0, opcionNIT = 0;
        decimal[] cantidad_producto;
        string[] nombre_articulo;
        string[] descripcion_art;
        string opcion_final = "", nombre = "", NIT = "", direccion = "";
        //como estetica unicamente, se genera un numero random, para usarlo como codigo de factura.
        Random random = new Random();
        int numAl = random.Next(1, 10000);
        //el siguiente doWhile esta usado para que se repita todo el codigo hasta que el usuario ingrese ---> Opcion3: Salir
        do
        {
            //Primer Menu, muestra las opcion del programa
            Console.Clear();
            Console.WriteLine("\t\t++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("\t\t+++++++++++++++ SUPER DESPENSA OAZYS UMG +++++++++++++++");
            Console.WriteLine("\t\t++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("\t\tINGRESE EL TIPO DE CLIENTE:");
            Console.WriteLine("\t\t1. CLIENTE MINORISTA");
            Console.WriteLine("\t\t2. CLIENTE MAYORISTA");
            Console.WriteLine("\t\t3. SALIR");
            Console.WriteLine("\t\t++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.Write("\t\tElija opcion: ");
            opcl = double.Parse(Console.ReadLine());
            subtotal = 0; total = 0; total_producto = new decimal[0];
            cantidad_producto = new decimal[0]; precio = new decimal[0]; nombre_articulo = new string[0]; descripcion_art = new string[0];
            descuento = 0; cantidad = 0;
            opcl = (int)opcl;
            switch (opcl)
            {
                //Opcion1 -----> Cliente minorista
                case 1:
                    Console.Clear();
                    Console.WriteLine("\t\t++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine("\t\t+++++++++++++++ SUPER DESPENSA OAZYS UMG +++++++++++++++");
                    Console.WriteLine("\t\t++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine("\t\tCLIENTE MINORISTA");
                    Console.ReadKey();
                    //Se ingresan datos del cliente ----> nombre,apellido y direccion
                    Console.WriteLine("\t\tIngrese nombre y apellido del cliente: ");
                    Console.Write("\t\t");
                    nombre = Console.ReadLine();
                    Console.WriteLine("\t\tIngrese su direccion: ");
                    Console.Write("\t\t");
                    direccion = Console.ReadLine();
                    //Se ingresan el numero de art. a ingresar, en donde el doWhile sirve para que esa cantidad no pueda ser <= 0
                    do
                    {
                        Console.WriteLine("\t\tCuantos articulos va ingresar?");
                        Console.Write("\t\t");
                        cantidad = double.Parse(Console.ReadLine());
                        Console.Clear();
                    } while (cantidad < 1);
                    //se le da el valor a los array, de la cantidad ingresada (cantidad da el valor a los arrays)
                    nombre_articulo = new string[(int)cantidad];
                    precio = new decimal[(int)cantidad];
                    cantidad_producto = new decimal[(int)cantidad];
                    total_producto = new decimal[(int)cantidad];
                    //este for se usa para llenar los arrays con los datos correspondientes ---> nom-art, precio, cantidad
                    for (int i = 0; i < (int)cantidad; i++)
                    {
                        Console.Write("\t\tIngrese nombre del producto: ");
                        nombre_articulo[i] = Console.ReadLine();
                        //el siguiente doWhile se esta usando para no ingresar valores <= 0
                        do
                        {
                            Console.Write("\t\tIngrese precio unitario del producto: Q");
                            precio[i] = decimal.Parse(Console.ReadLine());
                            Console.Write("\t\tIngrese cantidad de producto: ");
                            cantidad_producto[i] = decimal.Parse(Console.ReadLine());
                            Console.Clear();
                            //este if solo lo usamos para mostrar un mensaje del porque se esta repitiendo el codigo.
                            if (precio[i] <= 0 || (int)cantidad_producto[i] <= 0)
                            {
                                Console.WriteLine("\t\tNo es posible agregar precios o cantidades menores o iguales a 0");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {

                            }
                        } while (precio[i] <= 0 || (int)cantidad_producto[i] < 1);
                        //generamos un subtotal 
                        total_producto[i] = precio[i] * (int)cantidad_producto[i];
                        subtotal += total_producto[i];
                    }
                    //ya fuera del for metemos el valor total en la variable ---> total
                    total = subtotal;
                    //el siguiente doWhile lo usamos para que el fragmente de codigo se repita mientras
                    //el efectivo ingresado sea menor al total que se desea pagar
                    do
                    {
                        //inicializamos la varible en 0 para que el valor se reinicie cada vez que se se repita el fragmento de codigo.
                        monto_pago = 0;
                        Console.Clear();
                        Console.WriteLine("\t\tTotal a pagar: Q" + total);
                        Console.Write("\t\tEfectivo: Q");
                        monto_pago = decimal.Parse((Console.ReadLine()));
                    } while (monto_pago < total);
                    //se generea y muestra el cambio del cliente
                    cambio = monto_pago - total;
                    Console.WriteLine("\t\tCambio: Q" + cambio);
                    Console.ReadKey();
                    //el siguiente doWhile lo usamos para que se repita la pregunta ---> "Desea Nit para su factura?"
                    //siempre que se ingrese un numero != 1 o != 2
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("\t\tDesea Nit para su factura?");
                        Console.WriteLine("\t\t1. Si      |       2. No");
                        Console.Write("\t\t");
                        opcionNIT = double.Parse(Console.ReadLine());
                        //Si la opcion ingresada es 1 deja ingresar el valor del NIT de lo contrario se inicializa ---> "C/F"
                        if (opcionNIT == 1)
                        {
                            Console.WriteLine("\t\tIngrese NIT:");
                            Console.Write("\t\t");
                            NIT = Console.ReadLine();
                        }
                        else
                        {
                            NIT = "C/F";
                        }
                        Console.Clear();
                    } while (opcionNIT != 1 && opcionNIT != 2);
                    //SE MUESTRA LA FACTURA GENERADA.
                    Console.Clear();
                    Console.WriteLine("\t\t**** \t\tFACTURA MINORISTA\t\t ****");
                    Console.WriteLine("\t\t" + "{0,-20} {1,32}", "Codigo:", numAl);
                    Console.WriteLine("\t\tFecha: {0}", DateTime.Now.ToShortDateString()); //--> Muestra la fecha actual
                    Console.WriteLine("\t\tHora : {0}", DateTime.Now.ToString("HH:mm:ss")); //--> Muestra la hora exacta a la hora de emitir la factura.
                    Console.WriteLine("\t\tCliente: " + nombre);
                    Console.WriteLine("\t\tDirección: " + direccion);
                    Console.WriteLine("\t\tNIT: " + NIT);
                    Console.WriteLine("\t\t-----------------------------------------------------");
                    Console.WriteLine("\t\t" + "{0,-20} {1,10} {2,10} {3,10}", "Producto", "Cantidad", "Precio", "Total");
                    Console.WriteLine("\t\t-----------------------------------------------------");
                    //Lo usamos para que muestre los valores que se tienen en los arrays
                    for (int j = 0; j < (int)cantidad; j++)
                    {
                        Console.WriteLine("\t\t" + "{0,-20} {1,10} {2,10:C} {3,10:C}", nombre_articulo[j], (int)cantidad_producto[j], precio[j], cantidad_producto[j] * precio[j]);
                    }
                    Console.WriteLine("\t\t-----------------------------------------------------");
                    Console.WriteLine("\t\t" + "{0,-20} {1,32:C}", "Subtotal:", subtotal);
                    Console.WriteLine("\t\t-----------------------------------------------------");
                    Console.WriteLine("\t\t" + "{0,-20} {1,32:C}", "TOTAL:", total);
                    Console.WriteLine("\t\t" + "{0,-20} {1,32:C}", "Efectivo:", monto_pago);
                    Console.WriteLine("\t\t-----------------------------------------------------");
                    Console.WriteLine("\t\t" + "{0,-20} {1,32:C}", "Cambio:", cambio);
                    Console.WriteLine("\t\t" + "-----------------------------------------------------");
                    Console.WriteLine("\t\t" + "{0,35}", "GRACIAS POR SU COMPRA");
                    Console.WriteLine("\r\n\t\t\t\t          ▄\r\n\t\t\t\t        ▄▀░█\r\n\t\t\t\t   ██▄▄▄▀░░▀▀▀▀▄\r\n\t\t\t\t   ██░░░░░░░░░░█\r\n\t\t\t\t   ██▄▄▄░░░░░░░█\r\n\t\t\t\t   ▀▀   ▀▀▀▀▀▀▀\r\n\t\t\t\t ");
                    Console.WriteLine("\t\t" + "{0,35}", "VUELVA PRONTO!!!");
                    Console.WriteLine("\t\t-----------------------------------------------------");
                    Console.ReadKey();
                    break;

                case 2:
                    //Opcion2 -----> Cliente mayorista
                    Console.Clear();
                    Console.WriteLine("\t\t++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine("\t\t+++++++++++++++ SUPER DESPENSA OAZYS UMG +++++++++++++++");
                    Console.WriteLine("\t\t++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine("\t\tCLIENTE MAYORISTA");
                    Console.ReadKey();
                    //Se ingresan datos del cliente ----> nombre,apellido y direccion
                    Console.WriteLine("\t\tIngrese nombre y apellido del cliente: ");
                    Console.Write("\t\t");
                    nombre = Console.ReadLine();
                    Console.WriteLine("\t\tIngrese su direccion: ");
                    Console.Write("\t\t");
                    direccion = Console.ReadLine();

                    //Se ingresan el numero de art. a ingresar, en donde el doWhile sirve para que esa cantidad no pueda ser <= 0
                    do
                    {
                        Console.WriteLine("\t\tCuantos articulos va ingresar?");
                        Console.Write("\t\t");
                        cantidad = double.Parse(Console.ReadLine());
                        Console.Clear();
                    } while ((int)cantidad < 1);
                    //se le da el valor a los array, de la cantidad ingresada (cantidad da el valor a los arrays)
                    descripcion_art = new string[(int)cantidad];
                    nombre_articulo = new string[(int)cantidad];
                    precio = new decimal[(int)cantidad];
                    cantidad_producto = new decimal[(int)cantidad];
                    total_producto = new decimal[(int)cantidad];
                    //este for se usa para llenar los arrays con los datos correspondientes ---> nom-art, descripcion, precio, cantidad
                    for (int i = 0; i < (int)cantidad; i++)
                    {
                        Console.Write("\t\tIngrese nombre del producto: ");
                        nombre_articulo[i] = Console.ReadLine();
                        Console.Write("\t\tDescripcion: ");
                        descripcion_art[i] = Console.ReadLine();
                        //el siguiente doWhile se esta usando para no ingresar valores <= 0
                        do
                        {
                            Console.Write("\t\tIngrese precio individual del producto: Q");
                            precio[i] = decimal.Parse(Console.ReadLine());
                            Console.Write("\t\tIngrese cantidad de producto: ");
                            cantidad_producto[i] = decimal.Parse(Console.ReadLine());
                            Console.Clear();
                            //este if solo lo usamos para mostrar un mensaje del porque se esta repitiendo el codigo.
                            if (precio[i] <= 0 || (int)cantidad_producto[i] < 1)
                            {
                                Console.WriteLine("\t\tNo es posible agregar precios o cantidades menores o iguales 0");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {

                            }
                        } while (precio[i] <= 0 || (int)cantidad_producto[i] <= 0);
                        //generamos un subtotal 
                        total_producto[i] = precio[i] * (int)cantidad_producto[i];
                        subtotal += total_producto[i];
                    }
                    //los siguientes if los usamos para generar descuentos, estos solo los usamos para clientes mayorista donde:
                    //Si gasta entre 0 y 2500 ---> Sin Descuento
                    if (subtotal > 0 && subtotal < 2500)
                    {
                        total = subtotal;
                    }
                    //Si gasta entre 2501 y 4000 ---> Descuento del 5%
                    else if (subtotal > 2500 && subtotal <= 4000)
                    {
                        descuento = subtotal * 0.05M;
                        total = subtotal - descuento;
                    }
                    //Si gasta entre 4001 y 6000 ---> Descuento del 10%
                    else if (subtotal > 4000 && subtotal <= 6000)
                    {
                        descuento = subtotal * 0.10M;
                        total = subtotal - descuento;
                    }
                    //Si gasta de 6000 en adelante ---> Descuento del 20%
                    else if (subtotal > 6000)
                    {
                        descuento = subtotal * 0.20M;
                        total = subtotal - descuento;
                    }
                    //el siguiente doWhile lo usamos para que el fragmente de codigo se repita mientras
                    //el efectivo ingresado sea menor al total que se desea pagar
                    do
                    {
                        //inicializamos la varible en 0 para que el valor se reinicie cada vez que se se repita el fragmento de codigo.
                        monto_pago = 0;
                        Console.Clear();
                        Console.WriteLine("\t\tTotal a pagar: Q" + total);
                        Console.Write("\t\tEfectivo: Q");
                        monto_pago = decimal.Parse((Console.ReadLine()));
                    } while (monto_pago < total);
                    //mostramos el cambio que se debe dar al cliente
                    cambio = monto_pago - total;
                    Console.WriteLine("\t\tCambio: Q" + cambio);
                    Console.ReadKey();
                    Console.Clear();
                    //el siguiente doWhile lo usamos para que se repita la pregunta ---> "Desea Nit para su factura?"
                    //siempre que se ingrese un numero != 1 o != 2
                    do
                    {
                        Console.WriteLine("\t\tDesea Nit para su factura?");
                        Console.WriteLine("\t\t1. Si      |       2. No");
                        Console.Write("\t\t");
                        opcionNIT = double.Parse(Console.ReadLine());
                        //Si la opcion ingresada es 1 deja ingresar el valor del NIT de lo contrario se inicializa ---> "C/F"
                        if (opcionNIT == 1)
                        {
                            Console.WriteLine("\t\tIngrese NIT:");
                            Console.Write("\t\t");
                            NIT = Console.ReadLine();
                        }
                        else
                        {
                            NIT = "C/F";
                        }
                        Console.Clear();
                    } while (opcionNIT != 1 && opcionNIT != 2);
                    //SE MUESTRA LA FACTURA
                    Console.Clear();
                    Console.WriteLine("\t\t**** \t\t\tFACTURA MAYORISTA\t\t\t****");
                    Console.WriteLine("\t\t" + "{0,-20} {1,47}", "Codigo:", numAl);
                    Console.WriteLine("\t\tFecha: {0}", DateTime.Now.ToShortDateString()); //muestra la fecha actual
                    Console.WriteLine("\t\tHora : {0}", DateTime.Now.ToString("HH:mm:ss"));//muestra la hora exanta al momento de emitir la factura
                    Console.WriteLine("\t\tCliente: " + nombre);
                    Console.WriteLine("\t\tDirección: " + direccion);
                    Console.WriteLine("\t\tNIT: " + NIT);
                    Console.WriteLine("\t\t--------------------------------------------------------------------");
                    Console.WriteLine("\t\t" + "{0,-1} {1,15} {2,15} {3,15} {4,16}", "Ctd", "Descripcion", "Producto", "Precio", "Total");
                    Console.WriteLine("\t\t--------------------------------------------------------------------");
                    for (int j = 0; j < (int)cantidad; j++)
                    {
                        Console.WriteLine("\t\t" + "{0,-3} {1,15} {2,15} {3,15:C} {4,16:C}", (int)cantidad_producto[j], descripcion_art[j], nombre_articulo[j], precio[j], cantidad_producto[j] * precio[j]);
                    }
                    Console.WriteLine("\t\t--------------------------------------------------------------------");
                    Console.WriteLine("\t\t" + "{0,-20} {1,47:C}", "Subtotal:", subtotal);
                    Console.WriteLine("\t\t" + "{0,-20} {1,47:C}", "Descuento:", descuento);
                    Console.WriteLine("\t\t--------------------------------------------------------------------");
                    Console.WriteLine("\t\t" + "{0,-20} {1,47:C}", "TOTAL:", total);
                    Console.WriteLine("\t\t" + "{0,-20} {1,47:C}", "Efectivo:", monto_pago);
                    Console.WriteLine("\t\t--------------------------------------------------------------------");
                    Console.WriteLine("\t\t" + "{0,-20} {1,47:C}", "Cambio:", cambio);
                    Console.WriteLine("\t\t" + "--------------------------------------------------------------------");
                    Console.WriteLine("\t\t\t  " + "{0,35}", "GRACIAS POR SU COMPRA");
                    Console.WriteLine("\r\n\t\t\t\t\t            ▄\r\n\t\t\t\t\t          ▄▀░█\r\n\t\t\t\t\t     ██▄▄▄▀░░▀▀▀▀▄\r\n\t\t\t\t\t     ██░░░░░░░░░░█\r\n\t\t\t\t\t     ██▄▄▄░░░░░░░█\r\n\t\t\t\t\t     ▀▀   ▀▀▀▀▀▀▀\r\n\t\t\t\t ");
                    Console.WriteLine("\t\t" + "                           VUELVA PRONTO!!!");
                    Console.WriteLine("\t\t--------------------------------------------------------------------");
                    Console.ReadKey();
                    break;

                default:
                    //Opcion3 ---> Para salir del programa
                    Console.Clear();
                    //Mensaje de despedida
                    if ((int)opcl == 3)
                    {
                        Console.WriteLine("\t\t++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine("\t\t+++++++++++++++ SUPER DESPENSA OAZYS UMG +++++++++++++++");
                        Console.WriteLine("\t\t++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine("\t\t\t  GRACIAS POR USAR NUESTRO SISTEMA\n");
                        Console.WriteLine("\t\t\t                      ████████ \r\n\t\t\t  ███████          ███        ███\r\n\t\t\t  █      █       ███             ███\r\n\t\t\t   █      █    ██                   ██\r\n\t\t\t    █     █   ██     ██      ██      ███\r\n\t\t\t     █   █   █      ████    ████      ██\r\n\t\t\t   █████████████                      ██\r\n\t\t\t  █             █         █_          ██\r\n\t\t\t ██             █   ██          ██    ██\r\n\t\t\t██   ███████████     ██        ██     ██\r\n\t\t\t█               █      ████████       ██\r\n\t\t\t██              █                   ██\r\n\t\t\t █   ███████████                   ██\r\n\t\t\t ██          ████                 █\r\n\t\t\t  ████████████   █████████████████ ");
                        Console.WriteLine("\t\t++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    }
                    //este if es usado para mostrar un mensaje si en algun caso se ingresa una opcion incorrecta en el menu inial
                    else if ((int)opcl != 1 || (int)opcl != 2 || (int)opcl != 3)
                    {
                        Console.WriteLine("\t\t++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine("\t\t\t  OPCION INCORRECTA VUELVA A ELEGIR");
                        Console.WriteLine("\t\t++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine("\t\t\t    █████████████     ████████ \r\n\t\t\t   █             █ ███        ███\r\n\t\t\t  ██             █              ███\r\n\t\t\t ██   ███████████                 ██\r\n\t\t\t █               █   ██      ██     ███\r\n\t\t\t ██              █  ████    ████      ██\r\n\t\t\t  █   ███████████                     ██\r\n\t\t\t  ██         █████        █_          ██\r\n\t\t\t   ████████████                       ██\r\n\t\t\t      █   █                           ██\r\n\t\t\t     █     █ ██        ████████       ██\r\n\t\t\t    █      █  ██     ██        ██    ██\r\n\t\t\t   █      █     ██                 ██\r\n\t\t\t    ██████        █               █\r\n\t\t\t                   ███████████████ ");
                        Console.WriteLine("\t\t++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    }
                    
                    Console.ReadKey();
                    break;
            }
        } while ((int)opcl != 3);
    }
}
