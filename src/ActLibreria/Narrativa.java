package ActLibreria;

/**
 *
 * @author pc
 */
public class Narrativa extends Articulo {

    private String genero;
    private String tipo = "Narrativa";
    public Narrativa() {
        super();
    }

    public String getTipo() {
        return tipo;
    }

    @Override
    public void mostrartodo() {
        this.generarficha();
        System.out.println(" Clase " + this.getClass());
        System.out.println(" Genero " + this.getGenero());
    }

    public void setGenero(String genero) {
        this.genero = genero;
    }

    public String getGenero() {
        return genero;
    }



}
