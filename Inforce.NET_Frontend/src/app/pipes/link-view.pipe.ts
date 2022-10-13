import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'linkView'
})
export class LinkViewPipe implements PipeTransform {

  transform(value: string): string {
    if(value.length < 6){
      return value;
    }
    return value.slice(0, 5);
  }

}
