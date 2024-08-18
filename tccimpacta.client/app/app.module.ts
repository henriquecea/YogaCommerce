import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './components/app.component';
import { HttpClientModule } from '@angular/common/http';
import { RegisterComponent } from './tenant/views/register/register.component';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module'; 

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent
    // Declare outros componentes aqui
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
