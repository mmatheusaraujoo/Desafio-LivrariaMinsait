import { AbstractControl, FormControl, ValidatorFn } from '@angular/forms';

export function nonNumericValidator(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
        const nonNumeric = /[0-9]+/.test(control.value);
        return nonNumeric ? { 'nonNumeric': { value: control.value } } : null;
    };
}

export function DateValidator(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
        const regex = /^(0?[1-9]|[12]\d|3[01])\/((0?[1-9]|1[0-2])\/\d{4})$/;
        const isDate = regex.test(control.value);
        return isDate ? { 'isDate': { value: control.value } } : null;
    }
}

export function numberValidator(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
        if (control.value === '' || /^[0-9]+$/.test(control.value)) {
            return null;
        } else {
            return { 'number': true };
        }
    };
}
