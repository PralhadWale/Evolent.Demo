import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CoreModule } from './core/core.module';
import { MasterModule } from './master/master.module';

const routes: Routes = [
  {
    path: "contacts",
    loadChildren:() => import('src/app/master/master.module').then(m=> m.MasterModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes),CoreModule,MasterModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
