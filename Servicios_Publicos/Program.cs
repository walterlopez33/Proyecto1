using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static int tamano = 10;
    static int[] numeroPago = new int[tamano];
    static DateTime[] fecha = new DateTime[10];
    static TimeOnly[] hora = new TimeOnly[10];
    static string[] cedula = new string[10];
    static string[] nombre = new string[10];
    static string[] apellido1 = new string[10];
    static string[] apellido2 = new string[10];
    static int[] numeroCaja = new int[10];
    static int[] tipoServicio = new int[10];
    static int[] numeroFactura = new int[10];
    static double[] montoPagar = new double[10];
    static double[] montoComision = new double[10];
    static double[] montoDeducido = new double[10];
    static double[] montoPagaCliente = new double[10];
    static double[] vuelto = new double[10];
    static int indice = 0;


    static void Main()
    {
        MenuPrincipal();
    }
    static void MenuPrincipal()
    {
        try
        {            
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*****Pago de servios Publicos Murcia S.A*****");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("1. Inicializar Vectores");
                Console.WriteLine("2. Realizar Pagos");
                Console.WriteLine("3. Consultar Pagos");
                Console.WriteLine("4. Modificar Pagos");
                Console.WriteLine("5. Eliminar Pagos");
                Console.WriteLine("6. Submenú Reportes");
                Console.WriteLine("7. Salir");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Ingrese una opción: ");
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            InicializarVectores();
                            break;
                        case 2:
                            RealizarPagos();
                            break;
                        case 3:
                            ConsultarPagos();
                            break;
                        case 4:
                            ModificarPagos();
                            break;
                        case 5:
                            EliminarPagos();
                            break;
                        case 6:
                            SubmenuReportes();
                            break;
                        case 7:
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    Console.ReadKey();
                }
            } while (opcion != 7);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error en el Menú: " + e.Message);
            Console.ReadKey();
            MenuPrincipal();
        }
    }

    static void SubmenuReportes()
    {
        try
        {
            int opcionReportes;

            do
            {
                Console.Clear();

                Console.WriteLine("Submenú Reportes");
                Console.WriteLine("1. Ver todos los Pagos");
                Console.WriteLine("2. Ver Pagos por tipo de Servicio");
                Console.WriteLine("3. Ver Pagos por código de caja");
                Console.WriteLine("4. Ver Dinero Comisionado por servicios");
                Console.WriteLine("5. Regresar Menú Principal");

                Console.Write("Ingrese una opción: ");
                if (int.TryParse(Console.ReadLine(), out opcionReportes))
                {
                    switch (opcionReportes)
                    {
                        case 1:
                            VerTodosLosPagos();
                            break;
                        case 2:
                            VerPagosPorTipoServicio();
                            break;
                        case 3:
                            VerPagosPorCodigoCaja();
                            break;
                        case 4:
                            VerDineroComisionadoPorServicios();
                            break;
                        case 5:
                            Console.WriteLine("Regresando al Menú Principal...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }

                Console.WriteLine();
            } while (opcionReportes != 5);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error en el Sub Menú: " + e.Message);
            Console.ReadKey();
            MenuPrincipal();
        }
    }

    static void InicializarVectores() // procedimiento para Limpia arreglo
    {
        try
        {
            Console.Clear();

            numeroPago = Enumerable.Repeat(0, tamano).ToArray<int>();  //repite y pone valores en los espacios en blanco
            fecha = Enumerable.Repeat(DateTime.Parse("01/01/0001"), tamano).ToArray<DateTime>(); 
            hora = Enumerable.Repeat(TimeOnly.Parse("00:00"), tamano).ToArray<TimeOnly>();
            cedula = Enumerable.Repeat("", tamano).ToArray<string>();
            nombre = Enumerable.Repeat("", tamano).ToArray<string>();
            apellido1 = Enumerable.Repeat("", tamano).ToArray<string>();
            apellido2 = Enumerable.Repeat("", tamano).ToArray<string>();
            numeroCaja = Enumerable.Repeat(0, tamano).ToArray<int>();
            tipoServicio = Enumerable.Repeat(0, tamano).ToArray<int>();
            numeroFactura = Enumerable.Repeat(0, tamano).ToArray<int>();
            montoPagar = Enumerable.Repeat(0.0, tamano).ToArray<double>();
            montoComision = Enumerable.Repeat(0.0, tamano).ToArray<double>();
            montoDeducido = Enumerable.Repeat(0.0, tamano).ToArray<double>();
            montoPagaCliente = Enumerable.Repeat(0.0, tamano).ToArray<double>();
            vuelto = Enumerable.Repeat(0.0, tamano).ToArray<double>();
            Console.WriteLine("Vectores inicializados.");

            Console.ReadKey();
            MenuPrincipal();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al inicializar vectores: " + e.Message);
            Console.ReadKey();
            MenuPrincipal();
        }
    }

    static void RealizarPagos()
    {
        int posicion = 0;

        try
        {
            string continuar = "S";            

            do
            { 
                Console.Clear();

                posicion = Consecutivo();

                if (posicion == 10)
                {
                    Console.WriteLine("Vectores Llenos");
                    return;
                }
                else
                {
                    numeroPago[posicion] = posicion + 1;

                    Console.WriteLine("Numero de pago:  " + (posicion + 1).ToString());

                    Console.WriteLine("Ingrese la fecha (ej: '02/02/2024'):  ");
                    fecha[posicion] = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese la hora (ej: '14:00'):  "); 
                    hora[posicion] = TimeOnly.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese la cedula (ej: '0909990999'):  "); 
                    cedula[posicion] = Console.ReadLine();

                    Console.WriteLine("Ingrese el nombre:  "); 
                    nombre[posicion] = Console.ReadLine();

                    Console.WriteLine("Ingrese el primer apellido:  "); 
                    apellido1[posicion] = Console.ReadLine();

                    Console.WriteLine("Ingrese el segundo apellido:  "); 
                    apellido2[posicion] = Console.ReadLine();

                    //https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-integer-in-c
                    Random rnd = new Random();
                    int nCaja = rnd.Next(1, 4); //ramdom de 1 a 3
                    numeroCaja[posicion] = nCaja;
                    Console.WriteLine("Número de caja random:  " + nCaja);                

                    Console.WriteLine("Tipo de servicio ([1] recibo de luz, [2] servicio telefonico, [3] recibo de agua): "); 
                    int tServicio = int.Parse(Console.ReadLine());
                    if ((tServicio < 0) || (tServicio > 3))
                    {
                        Console.WriteLine("El Tipo de Servicio debe ser un número válido de 1 a 3");
                        Console.ReadKey();
                        return;
                    }
                    tipoServicio[posicion] = tServicio;

                    Console.WriteLine("Ingrese el numero de factura:  "); 
                    numeroFactura[posicion] = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el monto a pagar:  ");
                    double mPagar = 0;
                    mPagar = double.Parse(Console.ReadLine());
                    montoPagar[posicion] = mPagar;

                    double comision = 0;
                    switch (tServicio)
                    {
                        case 1:
                            comision = mPagar * 0.04; //4%
                            break;
                        case 2:
                            comision = mPagar * 0.055; //5.5%
                            break;
                        case 3:
                            comision = mPagar * 0.065; //6.5%
                            break;
                    }
                    Console.WriteLine("Comisión autorizada:  " + comision);
                    montoComision[posicion] = comision;

                    Console.WriteLine("Monto deducido:  " + (mPagar - comision).ToString());
                    montoDeducido[posicion] = (mPagar - comision);

                    Console.WriteLine("Ingrese el monto de pago cliente:  "); 
                    double PagoCliente = double.Parse(Console.ReadLine());                 
                    if (PagoCliente < mPagar)
                    {
                        Console.WriteLine("El Pago del Cliente es menor que el monto adeudado");
                        Console.ReadKey();
                        return;
                    }
                    montoPagaCliente[posicion] = PagoCliente;
                                        
                    double vueltoCliente = PagoCliente - mPagar;
                    vuelto[posicion] = vueltoCliente;
                    Console.WriteLine("El vuelto es de:  " + vueltoCliente);

                    Console.WriteLine("Pago registrado correctamente.");
                    Console.ReadKey();
                }

                do 
                {
                    Console.Clear();
                    Console.WriteLine("Desea continuar (S/N)");
                    string input = Console.ReadLine();
                    continuar = input.ToUpper();
                } while ((continuar != "S") && (continuar != "N"));

            } while (continuar != "N");

        }
        catch (Exception e)
        {
            Console.WriteLine("Error al guardar la información: " + e.Message);
            limpiarVector(posicion);
            Console.ReadKey();
            MenuPrincipal();
        }
    }

    static void limpiarVector(int pos)
    {
        numeroPago[pos] = 0;
        fecha[pos] = DateTime.Parse("01/01/0001");
        hora[pos] = TimeOnly.Parse("00:00");
        cedula[pos] = "";
        nombre[pos] = "";
        apellido1[pos] = "";
        apellido2[pos] = "";
        numeroCaja[pos] = 0;
        tipoServicio[pos] = 0;
        numeroFactura[pos] = 0;
        montoPagar[pos] = 0.0;
        montoComision[pos] = 0.0;
        montoDeducido[pos] = 0.0;
        montoPagaCliente[pos] = 0.0;
        vuelto[pos] = 0.0;
    }

    public static int Consecutivo()
    {
        try
        { 
            for (int i = 0; i < 10; i++)
            {
                if (numeroPago[i] == 0)
                {
                    return i;
                }
            }

            return 0;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            Console.ReadKey();
            return 10;         
        }
    }
    static void ConsultarPagos()
    {
        try
        {
            Console.Clear();

            Console.WriteLine("Digite el Número de Pago");
            int Nume = int.Parse(Console.ReadLine());

            if (Nume > 10)
            {
                Console.WriteLine("El número de Pago no puede ser mayor a 10");
                Console.ReadKey();
                return;
            }

            int posVector = Nume - 1;

            if (numeroPago[posVector] == 0)
            {
                Console.WriteLine("Pago no se encuentra Registrado");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Dato encontrado en la posición: " + posVector);
                Console.WriteLine("");
                Console.WriteLine("Presione cualquier tecla para ver Registo");
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine("Número de Pago     :  " + numeroPago[posVector]);
                Console.WriteLine("Fecha              :  " + fecha[posVector].ToShortDateString());
                Console.WriteLine("Hora               :  " + hora[posVector]);
                Console.WriteLine("Cédula             :  " + cedula[posVector]);
                Console.WriteLine("Nombre             :  " + nombre[posVector]);
                Console.WriteLine("Apellido 1         :  " + apellido1[posVector]);
                Console.WriteLine("Apelido 2          :  " + apellido2[posVector]);
                Console.WriteLine("Número de Caja     :  " + numeroCaja[posVector]);
                Console.WriteLine("Tipo de Servicio   :  " + tipoServicio[posVector]);
                Console.WriteLine("Número de Factura  :  " + numeroFactura[posVector]);
                Console.WriteLine("Monto a Pagar      :  " + montoPagar[posVector]);
                Console.WriteLine("Monto de Comisión  :  " + montoComision[posVector]);
                Console.WriteLine("Monto de Deducción :  " + montoDeducido[posVector]);
                Console.WriteLine("Monto Pago Cliente :  " + montoPagaCliente[posVector]);
                Console.WriteLine("Vuelto             :  " + vuelto[posVector]);

                Console.ReadKey();
                MenuPrincipal();
            }

        }
        catch (Exception e)
        {
            Console.WriteLine("Error cargando los datos: " + e.Message);
            Console.ReadKey();      
        }
    }
    static void ModificarPagos()
    {
        try
        {
            Console.Clear();

            Console.WriteLine("Digite el Número de Pago");
            int Nume = int.Parse(Console.ReadLine());

            if (Nume > 10)
            {
                Console.WriteLine("El número de Pago no puede ser mayor a 10");
                Console.ReadKey();
                return;
            }

            int posVector = Nume - 1;

            if (numeroPago[posVector] == 0)
            {
                Console.WriteLine("Pago no se encuentra Registrado");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Dato encontrado en la posición: " + posVector);
                Console.WriteLine("");
                Console.WriteLine("Presione cualquier tecla para modificar Registo");
                Console.ReadKey();

                Console.WriteLine("Numero de pago a Modificar:  " + Nume);

                Console.WriteLine("Ingrese la fecha (ej: '02/02/2024'):  ");
                fecha[posVector] = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese la hora (ej: '14:00'):  ");
                hora[posVector] = TimeOnly.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese la cedula (ej: '0909990999'):  ");
                cedula[posVector] = Console.ReadLine();

                Console.WriteLine("Ingrese el nombre:  ");
                nombre[posVector] = Console.ReadLine();

                Console.WriteLine("Ingrese el primer apellido:  ");
                apellido1[posVector] = Console.ReadLine();

                Console.WriteLine("Ingrese el segundo apellido:  ");
                apellido2[posVector] = Console.ReadLine();

                //https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-integer-in-c
                Random rnd = new Random();
                int nCaja = rnd.Next(1, 4); //ramdom de 1 a 3
                numeroCaja[posVector] = nCaja;
                Console.WriteLine("Número de caja random:  " + nCaja);

                Console.WriteLine("Tipo de servicio ([1] recibo de luz, [2] servicio telefonico, [3] recibo de agua): ");
                int tServicio = int.Parse(Console.ReadLine());
                if ((tServicio < 0) || (tServicio > 3))
                {
                    Console.WriteLine("El Tipo de Servicio debe ser un número válido de 1 a 3");
                    Console.ReadKey();
                    return;
                }
                tipoServicio[posVector] = tServicio;

                Console.WriteLine("Ingrese el numero de factura:  ");
                numeroFactura[posVector] = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el monto a pagar:  ");
                double mPagar = 0;
                mPagar = double.Parse(Console.ReadLine());
                montoPagar[posVector] = mPagar;

                double comision = 0;
                switch (tServicio)
                {
                    case 1:
                        comision = mPagar * 0.04; //4%
                        break;
                    case 2:
                        comision = mPagar * 0.055; //5.5%
                        break;
                    case 3:
                        comision = mPagar * 0.065; //6.5%
                        break;
                }
                Console.WriteLine("Comisión autorizada:  " + comision);
                montoComision[posVector] = comision;

                Console.WriteLine("Monto deducido:  " + (mPagar - comision).ToString());
                montoDeducido[posVector] = (mPagar - comision);

                Console.WriteLine("Ingrese el monto de pago cliente:  ");
                double PagoCliente = double.Parse(Console.ReadLine());
                if (PagoCliente < mPagar)
                {
                    Console.WriteLine("El Pago del Cliente es menor que el monto adeudado");
                    Console.ReadKey();
                    return;
                }
                montoPagaCliente[posVector] = PagoCliente;

                double vueltoCliente = PagoCliente - mPagar;
                vuelto[posVector] = vueltoCliente;
                Console.WriteLine("El vuelto es de:  " + vueltoCliente);

                Console.WriteLine("Pago modificado correctamente.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error cargando los datos: " + e.Message);
            Console.ReadKey();
        }
    }
    static void EliminarPagos()
    {
        try
        {
            Console.Clear();

            Console.WriteLine("Digite el Número de Pago que desea eliminar");
            int Nume = int.Parse(Console.ReadLine());

            if (Nume > 10)
            {
                Console.WriteLine("El número de Pago no puede ser mayor a 10");
                Console.ReadKey();
                return;
            }

            int posVector = Nume - 1;

            if (numeroPago[posVector] == 0)
            {
                Console.WriteLine("Pago no se encuentra Registrado");
                Console.ReadKey();
                return;
            }
            else
            {
                string eliminar = "";
                do 
                {
                    Console.Clear();
                    Console.WriteLine("Número de Pago     :  " + numeroPago[posVector]);
                    Console.WriteLine("Fecha              :  " + fecha[posVector]);
                    Console.WriteLine("Hora               :  " + hora[posVector]);
                    Console.WriteLine("Cédula             :  " + cedula[posVector]);
                    Console.WriteLine("Nombre             :  " + nombre[posVector]);
                    Console.WriteLine("Apellido 1         :  " + apellido1[posVector]);
                    Console.WriteLine("Apelido 2          :  " + apellido2[posVector]);
                    Console.WriteLine("Número de Caja     :  " + numeroCaja[posVector]);
                    Console.WriteLine("Tipo de Servicio   :  " + tipoServicio[posVector]);
                    Console.WriteLine("Número de Factura  :  " + numeroFactura[posVector]);
                    Console.WriteLine("Monto a Pagar      :  " + montoPagar[posVector]);
                    Console.WriteLine("Monto de Comisión  :  " + montoComision[posVector]);
                    Console.WriteLine("Monto de Deducción :  " + montoDeducido[posVector]);
                    Console.WriteLine("Monto Pago Cliente :  " + montoPagaCliente[posVector]);
                    Console.WriteLine("Vuelto             :  " + vuelto[posVector]);
                    Console.WriteLine("");
                    Console.WriteLine("Está seguro que desea eliminar este dato (S/N)");
                    string input = Console.ReadLine();
                    eliminar = input.ToUpper();
                } while ((eliminar != "S") && (eliminar != "N")) ;

                if (eliminar == "S")
                {
                    Console.Clear();
                    limpiarVector(posVector);
                    Console.WriteLine("La información ya fue eliminada");
                } 
                else
                {
                    Console.Clear();
                    Console.WriteLine("La información NO fue eliminada");
                }

                Console.ReadKey();
                MenuPrincipal();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error cargando los datos: " + e.Message);
            Console.ReadKey();
        }
    }



    static void VerTodosLosPagos()
    {
        try
        {
            Console.Clear();
            double mTotal = 0;
            int contador = 0;

            Console.WriteLine("Reporte de todos los pagos");
            Console.WriteLine("");
            Console.WriteLine("===============================================================================================================================");
            Console.WriteLine("# Pago  Fecha      Hora       Cédula      Nombre          Apellido 1          ApelLido 2          Monto Recibo          ");
            Console.WriteLine("===============================================================================================================================");

            for (int i = 0; i < 10; i++)
            {
                if (numeroPago[i] == 0)
                {
                    i = 10;
                }
                else
                {
                    Console.WriteLine(numeroPago[i].ToString().PadRight(8) + fecha[i].ToShortDateString().PadRight(11) + hora[i].ToString().PadRight(7) + cedula[i].ToString().PadRight(12) + nombre[i].ToString().PadRight(16) + apellido1[i].ToString().PadRight(20) + apellido2[i].ToString().PadRight(20) + montoPagar[i].ToString().PadRight(22));
                    mTotal = mTotal + montoPagar[i];
                    contador = contador + 1;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("===============================================================================================================================");
            Console.WriteLine("Total de registros: " + contador + "                                                                     Monto Total: " + mTotal);
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error cargando los datos: " + e.Message);
            Console.ReadKey();      
        }
    }

    static void VerPagosPorTipoServicio()
    {
        try
        {

            Console.Clear();

            Console.WriteLine("Digite el Tipo de Servicio ([1] recibo de luz, [2] servicio telefonico, [3] recibo de agua): ");
            int tServicio = int.Parse(Console.ReadLine());

            if (tServicio > 3)
            {
                Console.WriteLine("El Tipo de Servicio no puede ser mayor a 3");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            double mTotal = 0;
            int contador = 0;

            Console.WriteLine("Reporte de todos los pagos por Tipo de Servicio");
            Console.WriteLine("");
            Console.WriteLine("===============================================================================================================================");
            Console.WriteLine("# Pago  Fecha      Hora       Cédula      Nombre          Apellido 1          ApelLido 2          Monto Recibo          ");
            Console.WriteLine("===============================================================================================================================");

            for (int i = 0; i < 10; i++)
            {
                if (numeroPago[i] == 0)
                {
                    i = 10;
                }
                else
                {
                    if (tipoServicio[i] == tServicio)
                    {
                        Console.WriteLine(numeroPago[i].ToString().PadRight(8) + fecha[i].ToShortDateString().PadRight(11) + hora[i].ToString().PadRight(7) + cedula[i].ToString().PadRight(12) + nombre[i].ToString().PadRight(16) + apellido1[i].ToString().PadRight(20) + apellido2[i].ToString().PadRight(20) + montoPagar[i].ToString().PadRight(22));
                        mTotal = mTotal + montoPagar[i];
                        contador = contador + 1;
                    }
                }
            }

            Console.WriteLine("");
            Console.WriteLine("===============================================================================================================================");
            Console.WriteLine("Total de registros: " + contador + "                                                                     Monto Total: " + mTotal);
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error cargando los datos: " + e.Message);
            Console.ReadKey();
        }
    }

    static void VerPagosPorCodigoCaja()
    {
        try
        {

            Console.Clear();

            Console.WriteLine("Digite el Número de Caja (rango entre 1 y 3): ");
            int nCaja = int.Parse(Console.ReadLine());

            if (nCaja > 3)
            {
                Console.WriteLine("El Número de Caja no puede ser mayor a 3");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            double mTotal = 0;
            int contador = 0;

            Console.WriteLine("Reporte de todos los pagos por Código de Cajero");
            Console.WriteLine("");
            Console.WriteLine("===============================================================================================================================");
            Console.WriteLine("# Pago  Fecha      Hora       Cédula      Nombre          Apellido 1          ApelLido 2          Monto Recibo          ");
            Console.WriteLine("===============================================================================================================================");

            for (int i = 0; i < 10; i++)
            {
                if (numeroPago[i] == 0)
                {
                    i = 10;
                }
                else
                {
                    if (numeroCaja[i] == nCaja)
                    {
                        Console.WriteLine(numeroPago[i].ToString().PadRight(8) + fecha[i].ToShortDateString().PadRight(11) + hora[i].ToString().PadRight(7) + cedula[i].ToString().PadRight(12) + nombre[i].ToString().PadRight(16) + apellido1[i].ToString().PadRight(20) + apellido2[i].ToString().PadRight(20) + montoPagar[i].ToString().PadRight(22));
                        mTotal = mTotal + montoPagar[i];
                        contador = contador + 1;
                    }
                }
            }

            Console.WriteLine("");
            Console.WriteLine("===============================================================================================================================");
            Console.WriteLine("Total de registros: " + contador + "                                                                     Monto Total: " + mTotal);
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error cargando los datos: " + e.Message);
            Console.ReadKey();
        }

    }

    static void VerDineroComisionadoPorServicios()
    {
        try
        {
            Console.Clear();
            int cantElectricidad = 0;
            int cantTelefono = 0;
            int cantAgua= 0;
            double comisionElectricidad=0;
            double comisionTelefono = 0;
            double comisionAgua = 0;
            int contador = 0;

            Console.WriteLine("Reporte de dinero comisionado - Desglose por Tipo de Servicio");
            Console.WriteLine("");
            Console.WriteLine("===============================================================================");
            Console.WriteLine("ITEM              Cantidad de Transacciones         Total Comisionado          ");
            Console.WriteLine("===============================================================================");

            for (int i = 0; i < 10; i++)
            {
                if (numeroPago[i] == 0)
                {
                    i = 10;
                }
                else
                {
                    switch (tipoServicio[i])
                    {
                        case 1:
                            cantElectricidad = cantElectricidad + 1;
                            comisionElectricidad = comisionElectricidad + montoComision[i];
                            break;
                        case 2:
                            cantTelefono = cantTelefono + 1;
                            comisionTelefono = comisionTelefono + montoComision[i];
                            break;
                        case 3:
                            cantAgua = cantAgua + 1;
                            comisionAgua = comisionAgua + montoComision[i];
                            break;
                    }

                    contador = contador + 1;
                }
            }

            Console.WriteLine("1-Electricidad   " + cantElectricidad.ToString().PadRight(34) + comisionElectricidad.ToString());
            Console.WriteLine("2-Teléfono       " + cantTelefono.ToString().PadRight(34) + comisionTelefono.ToString());
            Console.WriteLine("3-Agua           " + cantAgua.ToString().PadRight(34) + comisionAgua.ToString());            
            Console.WriteLine("===============================================================================");
            Console.WriteLine("");
            Console.WriteLine("Total:           " + contador.ToString().PadRight(34) + (comisionElectricidad + comisionTelefono + comisionAgua).ToString());
            Console.WriteLine("");
            Console.WriteLine("===============================================================================");
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error cargando los datos: " + e.Message);
            Console.ReadKey();
        }
    }
}