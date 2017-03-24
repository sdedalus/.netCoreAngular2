import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule} from '@angular/http';

import { AppComponent }  from './app.component';
import { SamplesComponent } from './samples/samples.component';
import { app_routing } from './app.routing';
import { DataService } from './shared/services/data.service';
import { ValuesPipe } from './shared/ValuesPipe';

@NgModule({
    imports: [BrowserModule, FormsModule, ReactiveFormsModule, HttpModule, app_routing ],
    declarations: [AppComponent, SamplesComponent, ValuesPipe ],
  providers:    [ DataService ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }