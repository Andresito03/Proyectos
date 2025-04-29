package ActLibreria;

/**
 *
 * @author pc
 */
public class Ensayo extends Articulo {

    private int numeroensayosautor;
    private String tipo = "Ensayo";

    public Ensayo() {
        super();
    }

    public String getTipo() {
        return tipo;
    }

    @Override
    public void mostrartodo() {
        this.generarficha();
        System.out.println(" Clase " + this.getClass());
        System.out.println(" Numero de ensayos del autor " + this.getNumeroensayosautor());
    }

    public int getNumeroensayosautor() {
        return numeroensayosautor;
    }

    public void setNumeroensayosautor(int numeroensayosautor) {
        this.numeroensayosautor = numeroensayosautor;
    }

}
