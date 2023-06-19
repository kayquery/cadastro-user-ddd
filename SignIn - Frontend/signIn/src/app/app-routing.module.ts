
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './pages/list/list.component';
import { SignUpComponent } from './pages/sign-up/sign-up.component';

const routes: Routes = [
  {path:"", redirectTo: "signup", pathMatch: "full"},
  {path: "signup", component: SignUpComponent},
  {path: "signup/:id", component: SignUpComponent},
  {path: "listagem", component: ListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
