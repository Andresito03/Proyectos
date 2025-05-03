package ActLibreria;

/**
 *
 * @author pc
 */
public class Divulgacion extends Articulo {

    private String Ambito;
    private String tipo = "Divulgacion";

    public Divulgacion() {
        super();
    }

    public String getTipo() {
        return tipo;
    }

    public void setAmbito(String Ambito) {
        this.Ambito = Ambito;
    }

    @Override
    public void mostrartodo() {
        this.generarficha();
        System.out.println(" Clase " + this.getClass());
        System.out.println(" Ambito " + this.getAmbito());
    }

    public String getAmbito() {
        return Ambito;
    }

}
