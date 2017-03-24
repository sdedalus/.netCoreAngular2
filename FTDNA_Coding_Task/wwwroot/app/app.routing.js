"use strict";
var router_1 = require("@angular/router");
var samples_component_1 = require("./samples/samples.component");
var app_routes = [
    { path: '', pathMatch: 'full', redirectTo: '/samples' },
    { path: 'samples', component: samples_component_1.SamplesComponent }
];
exports.app_routing = router_1.RouterModule.forRoot(app_routes);
//# sourceMappingURL=app.routing.js.map