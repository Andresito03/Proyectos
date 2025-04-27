package Ficheros;

import java.util.Scanner;
import java.io.File;
import java.io.IOException;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.FileReader;

/**
 *
 * @author pc
 */
public class GestionInventario {

    public static void main(String[] arg) {

        Scanner inS = new Scanner(System.in);
        System.out.println("Introducir la ruta del archivo ");
        File archivo = new File(inS.nextLine());

        try {
            if (!archivo.exists()) {
                archivo.createNewFile();
            }

            menu(archivo);

        } catch (IOException e) {
            System.out.println("error");
        }

    }

    public static void menu(File archivo) {
        Scanner in = new Scanner(System.in);
        int opcion = 0;
        while (opcion != 9) {
            System.out.println("Menu--------");
            System.out.println("1. Introducir productos");
            System.out.println("2. Ver inventario");
            System.out.println("9. Salir");
            opcion = in.nextInt();
            switch (opcion) {
                case 1:
                    introproductos(archivo, in);
                    break;
                case 2:
                    verinventario(archivo, in);
                    break;
                case 9:
                    break;
                default:
                    break;
            }
        }
    }

    public static void introproductos(File archivo, Scanner in) {
        Scanner inS = new Scanner(System.in);
        try {
            BufferedWriter bw = new BufferedWriter(new FileWriter(archivo, true));
            System.out.println("Cuantos productos desea introducir");
            int numero = in.nextInt();
            while (numero < 0) {
                System.out.println("El numero no puede ser negativo");
                numero = in.nextInt();
            }
            int contador = 0;

            while (contador < numero) {
                System.out.println("Nombre del producto");
                bw.write(inS.nextLine() + " ");
                System.out.println("Precio individual");
                bw.write(inS.nextLine() + " ");
                System.out.println("Cantidad");
                bw.write(inS.nextLine() + " ");
                contador++;
                bw.newLine();
            }
            bw.close();
            System.out.println("Se introdujeron los productos");
        } catch (IOException e) {
            System.out.println("Error: "+ e.getMessage());
        }
    }

    public static void verinventario(File archivo, Scanner in) {

        try {

            BufferedReader br = new BufferedReader(new FileReader(archivo));
            String linea;
            double totalinventario = 0;
            while ((linea = br.readLine()) != null) {

                String producto[] = linea.split(" ");
                double totalproducto = Double.parseDouble(producto[1]) * Double.parseDouble(producto[2]);
                System.out.println("producto: " + producto[0]);
                System.out.println("Precio: " + producto[1]);
                System.out.println("Cantidad: " + producto[2]);
                System.out.println("Total: " + totalproducto);
                System.out.println("---------------");
                totalinventario += totalproducto;
            }
            System.out.println("Total inventario: " + totalinventario);
            br.close();
        } catch (IOException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
