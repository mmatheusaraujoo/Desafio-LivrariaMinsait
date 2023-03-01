export class FuncoesUteis {
    static converterParaData(data: string): Date {
        const dateStr = data;
        const [day, month, year] = dateStr.split('/');
        const newDateStr = `${year}/${month}/${day}`;
        const newDate = new Date(newDateStr);
        return newDate
    }

    static formatarData(data: Date | null): string {
        if (data == null) { return '' }
        const dia = String(data.getDate()).padStart(2, '0');
        const mes = String(data.getMonth() + 1).padStart(2, '0');
        const ano = String(data.getFullYear());
        return `${ano}/${mes}/${dia}`;
    }
}