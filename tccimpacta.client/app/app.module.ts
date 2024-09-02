import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './components/app.component';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';

import { ProductComponent } from './tenant/views/product/product.component';
import { ContactComponent } from './tenant/views/contact/contact.component';
import { HttpClientModule } from '@angular/common/http';
import { RegisterComponent } from './tenant/views/register/register.component';
import { LoginComponent } from './tenant/views/login/login.component';
import { HomeComponent } from './tenant/views/home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    HomeComponent,
    ProductComponent,
    ContactComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
    // Importe outros módulos aqui
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
