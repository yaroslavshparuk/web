import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component'
import { UsersComponent } from './users/users.component';
import { AddUserComponent } from './add-user/add-user.component';
import { EditUserComponent } from './edit.user/edit-user.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    UsersComponent,
    AddUserComponent,
    EditUserComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: UsersComponent },
      { path: 'add', component: AddUserComponent},
      { path: 'edit/:id', component: EditUserComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
