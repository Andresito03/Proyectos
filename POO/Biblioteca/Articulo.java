package ActLibreria;

abstract public class Articulo {

    protected String titulo;
    protected String isbn;
    protected String autor;
    protected String editorial;
    protected int ejemplares;
    protected float precio;

    public String getIsbn() {
        return isbn;
    }

    public Articulo() {
    }

    abstract public void mostrartodo();

    public void vender() {
        this.ejemplares = this.ejemplares - 1;
        System.out.println("Vendido por " + this.precio);
    }

    public void generarficha() {
        System.out.println("Imprimiendo datos...");
        System.out.println("  Título: " + this.getTitulo());
        System.out.println("  Autor: " + this.getAutor());
        System.out.println("  ISBN: " + this.getIsbn());
        System.out.println("  Precio: " + this.getPrecio() + " €");
    }

    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }

    public void setIsbn(String isbn) {
        this.isbn = isbn;
    }

    public void setAutor(String autor) {
        this.autor = autor;
    }

    public void setEditorial(String editorial) {
        this.editorial = editorial;
    }

    public void setEjemplares(int ejemplares) {
        this.ejemplares = ejemplares;
    }

    public void setPrecio(float precio) {
        this.precio = precio;
    }

    public String getTitulo() {
        return titulo;
    }

    public String getAutor() {
        return autor;
    }

    public String getEditorial() {
        return editorial;
    }

    public int getEjemplares() {
        return ejemplares;
    }

    public float getPrecio() {
        return precio;
    }

}
