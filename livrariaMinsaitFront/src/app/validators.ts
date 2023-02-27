import { AbstractControl, ValidatorFn } from '@angular/forms';

export function nonNumericValidator(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
        const nonNumeric = /[0-9]+/.test(control.value);
        return nonNumeric ? { 'nonNumeric': { value: control.value } } : null;
    };
}