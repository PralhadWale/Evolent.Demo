import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Apiservice } from './services/apiservice.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ActiveInactivePipe } from './services/active-inactive.pipe';



@NgModule({
  declarations: [ActiveInactivePipe],
  imports: [
    CommonModule,
    HttpClientModule
  ],
  exports:[ActiveInactivePipe],
  providers:[Apiservice]
})
export class CoreModule { }
