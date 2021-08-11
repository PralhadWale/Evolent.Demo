import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreatecontactComponent } from './contact/createcontact/createcontact.component';
import { ListcontactsComponent } from './contact/listcontacts/listcontacts.component';
import { CoreModule } from '../core/core.module';
import { Contactservice } from './contact/contactservice.service';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


const routes: Routes = [
  {
    path: "create",
    component: CreatecontactComponent
  },
  {
    path: "",
    component: ListcontactsComponent,
  }
];

@NgModule({
  declarations: [CreatecontactComponent, ListcontactsComponent],
  providers : [Contactservice],
  imports: [
    CommonModule,
    FormsModule, 
    ReactiveFormsModule,
    CoreModule,
    RouterModule.forChild(routes)
  ],
  exports:[ListcontactsComponent]
})
export class MasterModule { }
