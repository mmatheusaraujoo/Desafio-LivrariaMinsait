import { livro } from "./livro.models";

export class autor {
    public id: number;
    public nome: string;
    public dataDeNascimento: Date;
    public nacionalidade: string;
    public resumoBibliografico: string;
    public foto: string;
    public livros: livro[];

    constructor(
        id: number,
        nome: string,
        dataDeNascimento: Date,
        nacionalidade: string,
        resumoBibliografico: string,
        foto: string,
        livros: livro[]
    ) {
        this.id = id;
        this.nome = nome;
        this.dataDeNascimento = dataDeNascimento;
        this.nacionalidade = nacionalidade;
        this.resumoBibliografico = resumoBibliografico;
        this.foto = foto;
        this.livros = livros;
    }

}