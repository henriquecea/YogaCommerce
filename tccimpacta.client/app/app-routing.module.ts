import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './tenant/views/home/home.component';
import { LoginComponent } from './tenant/views/login/login.component';
import { RegisterComponent } from './tenant/views/register/register.component';
import { ContactComponent } from './tenant/views/contact/contact.component';
import { ProductComponent } from './tenant/views/product/product.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'product', component: ProductComponent }

  // Defina outras rotas 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
