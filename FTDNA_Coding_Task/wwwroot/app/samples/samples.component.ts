import { Component, OnInit } from '@angular/core';

import { DataService } from '../shared/services/data.service';
import { ISample, IStatus, IUser, ISampleRequest } from '../shared/interfaces';
//import { ValuesPipe } from '../shared/ValuesPipe';

@Component({
    moduleId: module.id,
    selector: 'samples',
    templateUrl: 'samples.component.html'
})
export class SamplesComponent implements OnInit {

    public editViewEnabled: boolean = false;

    public Barcode: string = "";
    public CreatedAt: string = "";
    public CreatedBy: string = "";
    public SampleId: string = "";
    public StatusId: string = "";

    public samples: ISample[] = [];
    public users:() => IUser[] = () => [];


    public statuses:() => IStatus[] = () => [];

    public errorMessage: string;

    public newSample: ISampleRequest = {
        Barcode: "",
        CreatedBy: "",
        StatusId: ""
    };

    public createNewSample() {
        return this.newSample = {
            Barcode: "",
            CreatedBy: "",
            StatusId: ""
        };
    }


    constructor(private dataService: DataService) {
        
    }

    seatch() {
        this.dataService.getSamples(this.SampleId, this.Barcode, this.CreatedAt, this.CreatedBy, this.StatusId)
            .subscribe((data: ISample[]) => this.samples = data);
    }

    createSample() {        
        this.dataService.postSamples(this.newSample)
            .subscribe(() => this.createNewSample());    
        this.newSample.Barcode = "";
        this.newSample.CreatedBy = "";
        this.newSample.StatusId = "";
    }

    ngOnInit() {
        this.dataService.getUsers()
            .subscribe((data: IUser[]) => {
                let userstmp = data.reverse().concat({ Id: "", UserName: "All" }).reverse();
                this.users = () => userstmp;
            });

        this.dataService.getStatuses()
            .subscribe((data: IStatus[]) => {
                let statusestmp = data.concat({ Id: "", Status: "All" }).reverse();
                this.statuses = () => statusestmp;
            });
    }
}