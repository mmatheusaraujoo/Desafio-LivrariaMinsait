import { autor } from "./autor.models";

export class livro {
    public id: number;
    public titulo: string;
    public subtitulo: string;
    public resumo: string;
    public quantidadeDePaginas: number;
    public dataDePublicacao: Date;
    public editora: string;
    public edicao: number;
    public isbn: string;
    public quantidadeEmEstoque: number;
    public fotoDaCapa: string;
    public autores: autor[]

    constructor(
        id: number,
        titulo: string,
        subtitulo: string,
        resumo: string,
        quantidadeDePaginas: number,
        dataDePublicacao: Date,
        editora: string,
        edicao: number,
        isbn: string,
        quantidadeEmEstoque: number,
        fotoDaCapa: string,
        autores: autor[]
    ) {
        this.id = id;
        this.titulo = titulo;
        this.subtitulo = subtitulo;
        this.resumo = resumo;
        this.quantidadeDePaginas = quantidadeDePaginas;
        this.dataDePublicacao = dataDePublicacao;
        this.editora = editora;
        this.edicao = edicao;
        this.isbn = isbn;
        this.quantidadeEmEstoque = quantidadeEmEstoque;
        this.fotoDaCapa = fotoDaCapa;
        this.autores = autores;
    }
}