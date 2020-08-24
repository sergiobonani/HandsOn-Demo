import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientComponent } from './components/client/client.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClientEditDialogComponent } from './components/client/edit/client-edit-dialog.component';
import { ClientDeleteDialogComponent } from './components/client/delete/client-delete-dialog.component';
import { AlertService } from './services/alert.service';
import { ClientService } from './services/client.service';
import { ToastrModule } from 'ngx-toastr';
import { HttpClientModule } from '@angular/common/http';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { NgxMaskModule } from 'ngx-mask';
import { LoadingComponent } from './components/loading/loading.component';
import { DatePipe, CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    ClientComponent,
    ClientEditDialogComponent,
    ClientDeleteDialogComponent,
    LoadingComponent,
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatDialogModule,
    FormsModule,
    MatButtonModule,
    MatInputModule,
    MatIconModule,
    MatSortModule,
    MatTableModule,
    MatToolbarModule,
    MatPaginatorModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    NgxMaskModule.forRoot()
  ],
  providers: [
    AlertService,
    ClientService,
    DatePipe
  ],
  entryComponents: [
    ClientComponent,
    ClientEditDialogComponent,
    ClientDeleteDialogComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
