import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module'                ;
import { AppComponent     } from './app.component'                     ;
import { NgbModule        } from '@ng-bootstrap/ng-bootstrap'          ;
import { ListComponent    } from './pages/list/list.component'         ;
import { NgxMaskModule    } from 'ngx-mask'                            ;
import { NavbarComponent  } from './components/navbar/navbar.component';
import { SignUpComponent  } from './pages/sign-up/sign-up.component'   ;
import { HttpClientModule } from '@angular/common/http'
import { ToastrModule           } from 'ngx-toastr'
import { FormControl, FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    AppComponent,
    ListComponent,
    NavbarComponent,
    SignUpComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    NgxMaskModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: 'toast-top-center',
      preventDuplicates: false,
      onActivateTick: true,
    }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
