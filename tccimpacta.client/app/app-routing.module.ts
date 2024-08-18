import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//import { HomeComponent } from './tenant/views/home/home.component';
//import { LoginComponent } from './tenant/views/login/login.component';
import { RegisterComponent } from './tenant/views/register/register.component';

const routes: Routes = [
  //{ path: '', component: HomeComponent },
  //{ path: '', component: LoginComponent },
  { path: 'register', component: RegisterComponent }
  // Defina outras rotas 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
