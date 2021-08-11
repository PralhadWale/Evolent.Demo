import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: "ActiveInactive"
})
export class ActiveInactivePipe implements PipeTransform {
  transform(value: any, ...args: any[]): any {
    return value ? "Active" : "InActive";
  }
}