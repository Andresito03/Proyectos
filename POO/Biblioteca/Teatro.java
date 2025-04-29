package ActLibreria;

/**
 *
 * @author pc
 */
public class Teatro extends Articulo {

    private String argumento;
    private String tipo = "Teatro";

    public Teatro() {
        super();
    }

    public String getTipo() {
        return tipo;
    }

    @Override
    public void mostrartodo() {
        this.generarficha();
        System.out.println(" Clase " + this.getClass());
        System.out.println(" Argumento " + this.getArgumento());
    }

    public void setArgumento(String argumento) {
        this.argumento = argumento;
    }

    public String getArgumento() {
        return argumento;
    }
}
