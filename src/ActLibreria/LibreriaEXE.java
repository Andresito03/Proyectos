package ActLibreria;

import java.io.File;
import java.io.IOException;
import java.util.Scanner;

/**
 *
 * @author Andre
 */
public class LibreriaEXE {

    public static void main(String[] args) {

        Articulo[] biblioteca = new Articulo[100];
        Scanner in = new Scanner(System.in);
        Scanner inS = new Scanner(System.in);
        cargarinfo(biblioteca);
        menu(biblioteca, in, inS);

    }

    public static void menu(Articulo[] biblioteca, Scanner in, Scanner inS) {
        String modificacion = "";
        int opcion = 0;
        while (opcion != 9) {
            System.out.println("1. Mostrar todo");
            System.out.println("2. Agregar articulo");
            System.out.println("3. Eliminar articulo");
            System.out.println("4. Mostrar editoriales");
            System.out.println("5. Vender un ejemplar");
            System.out.println("6. Modificar el precio de un articulo mediante el ISBN");
            System.out.println("7. Modificar todos los precios de un tipo de articulo");
            System.out.println("9. salir");
            opcion = in.nextInt();
            switch (opcion) {
                case 1:
                    mostrartodo(biblioteca);
                    break;
                case 2:
                    agregararticulo(biblioteca, inS, in);
                    break;
                case 3:
                    eliminararticulo(biblioteca, inS, in);
                    break;
                case 4:
                    MostrarEditoriales(biblioteca);
                    break;
                case 5:
                    Vender(biblioteca);
                    break;
                case 6:
                    System.out.println("Indica la modificacion con el formato indicado ( Sin decimales pls )");
                    System.out.println("   +10 -> Aumenta un 10 % el precio");
                    System.out.println("   -5 -> Disminuye un 5 % el precio");
                    modificacion = inS.nextLine();
                    modificarPrecioISBN(biblioteca, modificacion);

                    break;
                case 7:
                    System.out.println("Indica la modificacion con el formato indicado ( Sin decimales pls )");
                    System.out.println("   +10 -> Aumenta un 10 % el precio");
                    System.out.println("   -5 -> Disminuye un 5 % el precio");
                    modificacion = inS.nextLine();
                    AumentarPrecioTipo(biblioteca, modificacion);
                    break;
                case 9:
                    break;
                default:
                    System.out.println("Opcion incorrecta");
                    break;
            }
        }
    }

    public static void mostrartodo(Articulo[] biblioteca) {
        for (int i = 0; i < biblioteca.length; i++) {
            if (biblioteca[i] != null) {
                biblioteca[i].mostrartodo();
            }
        }
    }

    public static void agregararticulo(Articulo[] biblioteca, Scanner inS, Scanner in) {
        int i = lugarvacio(biblioteca);
        int error = 0;
        String titulo = "";
        String isbn = "";
        String autor = "";
        String editorial = "";
        int ejemplares = 0;
        float precio = 0;

        if (i != -1) {
            System.out.println("Qué tipo de artículo desea agregar");
            System.out.println("1. Narrativa");
            System.out.println("2. Teatro");
            System.out.println("3. Divulgación");
            System.out.println("4. Ensayo");
            int opcion = in.nextInt();
            in.nextLine();

            if (opcion > 0 && opcion < 5) {
                System.out.println("Introducir título");
                titulo = inS.nextLine();
                System.out.println("Introducir ISBN");
                isbn = inS.nextLine();
                System.out.println("Introducir autor");
                autor = inS.nextLine();
                System.out.println("Introducir editorial");
                editorial = inS.nextLine();
                System.out.println("Introducir ejemplares");
                ejemplares = in.nextInt();
                System.out.println("Introducir precio");
                precio = in.nextFloat();
                in.nextLine();

                switch (opcion) {
                    case 1:
                        biblioteca[i] = new Narrativa();
                        System.out.println("Introducir género de narrativa");
                        ((Narrativa) biblioteca[i]).setGenero(inS.nextLine());
                        break;
                    case 2:
                        biblioteca[i] = new Teatro();
                        System.out.println("Introducir argumento");
                        ((Teatro) biblioteca[i]).setArgumento(inS.nextLine());
                        break;
                    case 3:
                        biblioteca[i] = new Divulgacion();
                        System.out.println("Introducir ámbito");
                        ((Divulgacion) biblioteca[i]).setAmbito(inS.nextLine());
                        break;
                    case 4:
                        biblioteca[i] = new Ensayo();
                        System.out.println("Introducir número de ensayos del autor");
                        ((Ensayo) biblioteca[i]).setNumeroensayosautor(in.nextInt());
                        in.nextLine();
                        break;
                    default:
                        System.out.println("Opción incorrecta");
                        error++;
                        break;
                }

                if (error == 0) {
                    biblioteca[i].setTitulo(titulo);
                    biblioteca[i].setIsbn(isbn);
                    biblioteca[i].setAutor(autor);
                    biblioteca[i].setEditorial(editorial);
                    biblioteca[i].setEjemplares(ejemplares);
                    biblioteca[i].setPrecio(precio);
                }

            } else {
                System.out.println("Opción inválida");
            }

        } else {
            System.out.println("El array está lleno");
        }
    }

    public static void eliminararticulo(Articulo[] biblioteca, Scanner inS, Scanner in) {
        int ubi = buscar(biblioteca, inS);
        int opcion;
        if (ubi > -1) {
            System.out.println("Se eliminara, ¿Esta seguro?");
            biblioteca[ubi].generarficha();
            System.out.println("1. Si");
            System.out.println("2. no");
            opcion = in.nextInt();
            switch (opcion) {
                case 1:
                    biblioteca[ubi] = null;
                    System.out.println("Eliminado");
                    break;
                case 2:
                    System.out.println("No se eliminara");
                    break;
                default:
                    System.out.println("Opcion incorrecta");
                    break;
            }
        } else {
            System.out.println("No se encontro el ISBN ");
        }
    }

    public static void cargarinfo(Articulo[] biblioteca) {

        System.out.println("Introducir direccion del archivo");
        Scanner in = new Scanner(System.in);
        File archivo = new File(in.nextLine());
        int count = 0;

        try {
            if (archivo.exists()) {

                Scanner Scanner = new Scanner(archivo);
                String linea;
                int error = 0;
                while (Scanner.hasNext()) {
                    linea = Scanner.nextLine();
                    String[] articulo = linea.split(";");
                    count = lugarvacio(biblioteca);
                    if (count == -1) {
                        error++;
                    }
                    if (count < biblioteca.length && count != -1) {
                        if (biblioteca[count] == null) {
                            switch (articulo[0]) {
                                case "Narrativa":
                                    biblioteca[count] = new Narrativa();
                                    ((Narrativa) biblioteca[count]).setGenero(articulo[7]);
                                    break;
                                case "Teatro":
                                    biblioteca[count] = new Teatro();
                                    ((Teatro) biblioteca[count]).setArgumento(articulo[7]);
                                    break;
                                case "Ensayo":
                                    biblioteca[count] = new Ensayo();
                                    ((Ensayo) biblioteca[count]).setNumeroensayosautor(Integer.parseInt(articulo[7]));
                                    break;
                                case "Divulgacion":
                                    biblioteca[count] = new Divulgacion();
                                    ((Divulgacion) biblioteca[count]).setAmbito(articulo[7]);
                                    break;
                                default:
                                    System.out.println("Registro " + count + " incorrecto");
                                    error = 1;
                            }
                            if (error == 0) {
                                //Podem ja introduir els elements comuns
                                biblioteca[count].setTitulo(articulo[1]);
                                biblioteca[count].setIsbn(articulo[2]);
                                biblioteca[count].setAutor(articulo[3]);
                                biblioteca[count].setEditorial(articulo[4]);
                                biblioteca[count].setEjemplares(Integer.parseInt(articulo[5]));
                                biblioteca[count].setPrecio(Float.parseFloat(articulo[6]));
                            }

                        }
                    }
                }

            } else {
                System.out.println("El archivo no existe pailas");
            }
        } catch (IOException e) {
            System.out.println("Error " + e);
        }
    }

    public static int buscar(Articulo[] biblioteca, Scanner inS) {

        int ubi = -1;
        System.out.println("Introducir isbn");
        String isbn = inS.nextLine();
        for (int i = 0; i < biblioteca.length; i++) {
            if (biblioteca[i] != null) {
                if (biblioteca[i].getIsbn().equals(isbn)) {
                    ubi = i;
                    i = biblioteca.length;
                }

            }
        }
        if (ubi == -1) {
            System.out.println("No se encontro");
        }
        return ubi;
    }

    public static int lugarvacio(Articulo[] biblioteca) {
        for (int i = 0; i < biblioteca.length; i++) {
            if (biblioteca[i] == null) {
                return i;
            }
        }
        return -1; // No hay posiciones vacías
    }

    public static void MostrarEditoriales(Articulo[] biblioteca) {
        String[] editorialesMostradas = new String[biblioteca.length];
        int totalMostradas = 0;

        for (int i = 0; i < biblioteca.length; i++) {
            if (biblioteca[i] != null) {
                String editorial = biblioteca[i].getEditorial();
                boolean yaMostrada = false;

                for (int j = 0; j < totalMostradas; j++) {
                    if (editorial.equals(editorialesMostradas[j])) {
                        yaMostrada = true;
                        j = j + totalMostradas;
                    }
                }

                if (!yaMostrada) {
                    System.out.println(editorial);
                    editorialesMostradas[totalMostradas] = editorial;
                    totalMostradas++;
                }
            }
        }
    }

    public static void Vender(Articulo[] biblioteca) {
        Scanner inS = new Scanner(System.in);
        System.out.println("Introducir el nombre de el Articulo");
        String nombre = inS.nextLine();
        boolean vendido = false;
        for (int i = 0; i < biblioteca.length; i++) {
            if (biblioteca[i] != null) {
                if (nombre.equals(biblioteca[i].getTitulo())) {
                    if (biblioteca[i].getEjemplares() > 0) {
                        biblioteca[i].vender();
                        vendido = true;
                        i = biblioteca.length + i;
                    } else {
                        System.out.println("No hay existencias");
                        i = biblioteca.length + i;
                    }
                }
            }
        }

        if (!vendido) {
            System.out.println("No se pudo vender");
        }
    }

    public static void modificarPrecioISBN(Articulo[] biblioteca, String modificacion) {
        Scanner inS = new Scanner(System.in);
        String operacion = modificacion.substring(0, 1);
        float porcentaje = Float.parseFloat(modificacion.substring(1));

        int posicion = buscar(biblioteca, inS); // usamos la función que ya tienes

        if (posicion != -1) {
            Articulo articulo = biblioteca[posicion];

            System.out.println("Precio del artículo antes: " + articulo.getPrecio());

            if (operacion.equals("+")) {
                articulo.setPrecio(articulo.getPrecio() * (1 + (porcentaje / 100)));
            } else if (operacion.equals("-")) {
                articulo.setPrecio(articulo.getPrecio() * (1 - (porcentaje / 100)));
            } else {
                System.out.println("Operación no válida.");
            }

            System.out.println("Precio del artículo después: " + articulo.getPrecio());
        }
    }

    public static void AumentarPrecioTipo(Articulo[] biblioteca, String modificacion) {
        Scanner inS = new Scanner(System.in);
        String operacion = modificacion.substring(0, 1);
        float porcentaje = Float.parseFloat(modificacion.substring(1));

        float multiplicador;
        if (operacion.equals("+")) {
            multiplicador = 1 + (porcentaje / 100);
        } else {
            multiplicador = 1 - (porcentaje / 100);
        }

        System.out.println("Introducir tipo (Narrativa, Teatro, Ensayo, Divulgacion):");
        String tipo = inS.nextLine();

        boolean encontrado = false;

        for (int i = 0; i < biblioteca.length; i++) {
            if (biblioteca[i] != null) {
                boolean coincideTipo
                        = (tipo.equals("Narrativa") && biblioteca[i] instanceof Narrativa)
                        || (tipo.equals("Teatre") && biblioteca[i] instanceof Teatro)
                        || (tipo.equals("Assaig") && biblioteca[i] instanceof Ensayo)
                        || (tipo.equals("Divulgació") && biblioteca[i] instanceof Divulgacion);

                if (coincideTipo) {
                    System.out.println(biblioteca[i].getTitulo());
                    System.out.println("Precio antes: " + biblioteca[i].getPrecio());
                    biblioteca[i].setPrecio(biblioteca[i].getPrecio() * multiplicador);
                    System.out.println("Precio después: " + biblioteca[i].getPrecio());
                    encontrado = true;
                }
            }
        }

        if (!encontrado) {
            System.out.println("No se encontraron artículos del tipo indicado.");
        }

    }
}
