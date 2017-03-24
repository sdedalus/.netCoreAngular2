import { RouterModule, Routes } from '@angular/router';

import { SamplesComponent }     from './samples/samples.component';

const app_routes: Routes = [
  { path: '',  pathMatch:'full', redirectTo: '/samples' },
  { path: 'samples', component: SamplesComponent }
];

export const app_routing = RouterModule.forRoot(app_routes);