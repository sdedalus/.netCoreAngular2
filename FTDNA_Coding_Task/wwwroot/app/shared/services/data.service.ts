
import { Injectable } from "@angular/core";
import { Http, Response, Headers, RequestOptions } from "@angular/http";

import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import { Observable } from "rxjs/Rx";

import { ISample, IStatus, IUser, ISampleRequest } from "../interfaces";

@Injectable()
export class DataService {
    // this should come from the api/home controller getmethod 
    // that bootstrap step was skipped in this task in the interest of time 
    // but would be usefull in a public api to facilitate api versioning 
    // and reduce resource / identifier coupling.
    private samples: string = 'api/samples?{id}{barcode}{createdAt}{createdBy}{statusId}{nameContains}';
    private sample: string = 'api/samples';
    private users: string = 'api/users';
    private statuses: string = 'api/statuses';
    
    constructor(private http: Http) { }

    getSamples(id: string, barcode: string, createdat: string, createdby: string, statusid: string, nameContains: string): Observable<ISample[]> {

        var query: string;
        query = this.setOptionalQueryPart(this.samples, "id", id);
        query = this.setOptionalQueryPart(query, "barcode", barcode);
        query = this.setOptionalQueryPart(query, "createdAt", createdat);
        query = this.setOptionalQueryPart(query, "createdBy", createdby);
        query = this.setOptionalQueryPart(query, "statusId", statusid);
        query = this.setOptionalQueryPart(query, "nameContains", nameContains);
        if (query.endsWith("&")){
            query = query.substring(0, query.length - 1);
        }

        return this.http.get(query)
                   .map((resp: Response) => resp.json())
                   .catch(this.handleError);
    } 

    postSamples(postBody: ISampleRequest): Observable<ISample[]> {

        var query = this.sample;
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(query, postBody, options)
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    } 

    getUsers(): Observable<IUser[]> { 
        return this.http.get(this.users)
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    getStatuses(): Observable<IStatus[]> {
        return this.http.get(this.statuses)
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    private setOptionalQueryPart(query: string, name: string, value: string) {
        var token = "{" + name + "}"
        if (value) {
            return query.replace(token, name + "=" + value + "&");
        } else {
            return query.replace(token, "");
        }
    }
    
    handleError(error: any) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
    
}
