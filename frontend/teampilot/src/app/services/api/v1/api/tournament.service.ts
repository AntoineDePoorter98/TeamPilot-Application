/**
 * TeamPilot.Api
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
/* tslint:disable:no-unused-variable member-ordering */

import { Inject, Injectable, Optional }                      from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,
         HttpResponse, HttpEvent, HttpParameterCodec, HttpContext 
        }       from '@angular/common/http';
import { CustomHttpParameterCodec }                          from '../encoder';
import { Observable }                                        from 'rxjs';

// @ts-ignore
import { NewTournamentDTO } from '../model/newTournamentDTO';
// @ts-ignore
import { TeamForTournamentDTO } from '../model/teamForTournamentDTO';
// @ts-ignore
import { TournamentDTO } from '../model/tournamentDTO';
// @ts-ignore
import { TournamentForManagerDTO } from '../model/tournamentForManagerDTO';

// @ts-ignore
import { BASE_PATH, COLLECTION_FORMATS }                     from '../variables';
import { Configuration }                                     from '../configuration';



@Injectable({
  providedIn: 'root'
})
export class TournamentService {

    protected basePath = 'https://localhost:5000';
    public defaultHeaders = new HttpHeaders();
    public configuration = new Configuration();
    public encoder: HttpParameterCodec;

    constructor(protected httpClient: HttpClient, @Optional()@Inject(BASE_PATH) basePath: string|string[], @Optional() configuration: Configuration) {
        if (configuration) {
            this.configuration = configuration;
        }
        if (typeof this.configuration.basePath !== 'string') {
            if (Array.isArray(basePath) && basePath.length > 0) {
                basePath = basePath[0];
            }

            if (typeof basePath !== 'string') {
                basePath = this.basePath;
            }
            this.configuration.basePath = basePath;
        }
        this.encoder = this.configuration.encoder || new CustomHttpParameterCodec();
    }


    // @ts-ignore
    private addToHttpParams(httpParams: HttpParams, value: any, key?: string): HttpParams {
        if (typeof value === "object" && value instanceof Date === false) {
            httpParams = this.addToHttpParamsRecursive(httpParams, value);
        } else {
            httpParams = this.addToHttpParamsRecursive(httpParams, value, key);
        }
        return httpParams;
    }

    private addToHttpParamsRecursive(httpParams: HttpParams, value?: any, key?: string): HttpParams {
        if (value == null) {
            return httpParams;
        }

        if (typeof value === "object") {
            if (Array.isArray(value)) {
                (value as any[]).forEach( elem => httpParams = this.addToHttpParamsRecursive(httpParams, elem, key));
            } else if (value instanceof Date) {
                if (key != null) {
                    httpParams = httpParams.append(key, (value as Date).toISOString().substr(0, 10));
                } else {
                   throw Error("key may not be null if value is Date");
                }
            } else {
                Object.keys(value).forEach( k => httpParams = this.addToHttpParamsRecursive(
                    httpParams, value[k], key != null ? `${key}.${k}` : k));
            }
        } else if (key != null) {
            httpParams = httpParams.append(key, value);
        } else {
            throw Error("key may not be null if value is not object or array");
        }
        return httpParams;
    }

    /**
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public tournamentsGet(observe?: 'body', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<Array<TournamentDTO>>;
    public tournamentsGet(observe?: 'response', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpResponse<Array<TournamentDTO>>>;
    public tournamentsGet(observe?: 'events', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpEvent<Array<TournamentDTO>>>;
    public tournamentsGet(observe: any = 'body', reportProgress: boolean = false, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<any> {

        let localVarHeaders = this.defaultHeaders;

        let localVarHttpHeaderAcceptSelected: string | undefined = options && options.httpHeaderAccept;
        if (localVarHttpHeaderAcceptSelected === undefined) {
            // to determine the Accept header
            const httpHeaderAccepts: string[] = [
                'text/plain',
                'application/json',
                'text/json'
            ];
            localVarHttpHeaderAcceptSelected = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        }
        if (localVarHttpHeaderAcceptSelected !== undefined) {
            localVarHeaders = localVarHeaders.set('Accept', localVarHttpHeaderAcceptSelected);
        }

        let localVarHttpContext: HttpContext | undefined = options && options.context;
        if (localVarHttpContext === undefined) {
            localVarHttpContext = new HttpContext();
        }


        let responseType_: 'text' | 'json' | 'blob' = 'json';
        if (localVarHttpHeaderAcceptSelected) {
            if (localVarHttpHeaderAcceptSelected.startsWith('text')) {
                responseType_ = 'text';
            } else if (this.configuration.isJsonMime(localVarHttpHeaderAcceptSelected)) {
                responseType_ = 'json';
            } else {
                responseType_ = 'blob';
            }
        }

        let localVarPath = `/tournaments`;
        return this.httpClient.request<Array<TournamentDTO>>('get', `${this.configuration.basePath}${localVarPath}`,
            {
                context: localVarHttpContext,
                responseType: <any>responseType_,
                withCredentials: this.configuration.withCredentials,
                headers: localVarHeaders,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * @param id 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public tournamentsIdDelete(id: string, observe?: 'body', reportProgress?: boolean, options?: {httpHeaderAccept?: undefined, context?: HttpContext}): Observable<any>;
    public tournamentsIdDelete(id: string, observe?: 'response', reportProgress?: boolean, options?: {httpHeaderAccept?: undefined, context?: HttpContext}): Observable<HttpResponse<any>>;
    public tournamentsIdDelete(id: string, observe?: 'events', reportProgress?: boolean, options?: {httpHeaderAccept?: undefined, context?: HttpContext}): Observable<HttpEvent<any>>;
    public tournamentsIdDelete(id: string, observe: any = 'body', reportProgress: boolean = false, options?: {httpHeaderAccept?: undefined, context?: HttpContext}): Observable<any> {
        if (id === null || id === undefined) {
            throw new Error('Required parameter id was null or undefined when calling tournamentsIdDelete.');
        }

        let localVarHeaders = this.defaultHeaders;

        let localVarHttpHeaderAcceptSelected: string | undefined = options && options.httpHeaderAccept;
        if (localVarHttpHeaderAcceptSelected === undefined) {
            // to determine the Accept header
            const httpHeaderAccepts: string[] = [
            ];
            localVarHttpHeaderAcceptSelected = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        }
        if (localVarHttpHeaderAcceptSelected !== undefined) {
            localVarHeaders = localVarHeaders.set('Accept', localVarHttpHeaderAcceptSelected);
        }

        let localVarHttpContext: HttpContext | undefined = options && options.context;
        if (localVarHttpContext === undefined) {
            localVarHttpContext = new HttpContext();
        }


        let responseType_: 'text' | 'json' | 'blob' = 'json';
        if (localVarHttpHeaderAcceptSelected) {
            if (localVarHttpHeaderAcceptSelected.startsWith('text')) {
                responseType_ = 'text';
            } else if (this.configuration.isJsonMime(localVarHttpHeaderAcceptSelected)) {
                responseType_ = 'json';
            } else {
                responseType_ = 'blob';
            }
        }

        let localVarPath = `/tournaments/${this.configuration.encodeParam({name: "id", value: id, in: "path", style: "simple", explode: false, dataType: "string", dataFormat: undefined})}`;
        return this.httpClient.request<any>('delete', `${this.configuration.basePath}${localVarPath}`,
            {
                context: localVarHttpContext,
                responseType: <any>responseType_,
                withCredentials: this.configuration.withCredentials,
                headers: localVarHeaders,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * @param id 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public tournamentsIdGet(id: string, observe?: 'body', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<TournamentDTO>;
    public tournamentsIdGet(id: string, observe?: 'response', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpResponse<TournamentDTO>>;
    public tournamentsIdGet(id: string, observe?: 'events', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpEvent<TournamentDTO>>;
    public tournamentsIdGet(id: string, observe: any = 'body', reportProgress: boolean = false, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<any> {
        if (id === null || id === undefined) {
            throw new Error('Required parameter id was null or undefined when calling tournamentsIdGet.');
        }

        let localVarHeaders = this.defaultHeaders;

        let localVarHttpHeaderAcceptSelected: string | undefined = options && options.httpHeaderAccept;
        if (localVarHttpHeaderAcceptSelected === undefined) {
            // to determine the Accept header
            const httpHeaderAccepts: string[] = [
                'text/plain',
                'application/json',
                'text/json'
            ];
            localVarHttpHeaderAcceptSelected = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        }
        if (localVarHttpHeaderAcceptSelected !== undefined) {
            localVarHeaders = localVarHeaders.set('Accept', localVarHttpHeaderAcceptSelected);
        }

        let localVarHttpContext: HttpContext | undefined = options && options.context;
        if (localVarHttpContext === undefined) {
            localVarHttpContext = new HttpContext();
        }


        let responseType_: 'text' | 'json' | 'blob' = 'json';
        if (localVarHttpHeaderAcceptSelected) {
            if (localVarHttpHeaderAcceptSelected.startsWith('text')) {
                responseType_ = 'text';
            } else if (this.configuration.isJsonMime(localVarHttpHeaderAcceptSelected)) {
                responseType_ = 'json';
            } else {
                responseType_ = 'blob';
            }
        }

        let localVarPath = `/tournaments/${this.configuration.encodeParam({name: "id", value: id, in: "path", style: "simple", explode: false, dataType: "string", dataFormat: undefined})}`;
        return this.httpClient.request<TournamentDTO>('get', `${this.configuration.basePath}${localVarPath}`,
            {
                context: localVarHttpContext,
                responseType: <any>responseType_,
                withCredentials: this.configuration.withCredentials,
                headers: localVarHeaders,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * @param id 
     * @param newTournamentDTO 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public tournamentsIdPut(id: string, newTournamentDTO?: NewTournamentDTO, observe?: 'body', reportProgress?: boolean, options?: {httpHeaderAccept?: undefined, context?: HttpContext}): Observable<any>;
    public tournamentsIdPut(id: string, newTournamentDTO?: NewTournamentDTO, observe?: 'response', reportProgress?: boolean, options?: {httpHeaderAccept?: undefined, context?: HttpContext}): Observable<HttpResponse<any>>;
    public tournamentsIdPut(id: string, newTournamentDTO?: NewTournamentDTO, observe?: 'events', reportProgress?: boolean, options?: {httpHeaderAccept?: undefined, context?: HttpContext}): Observable<HttpEvent<any>>;
    public tournamentsIdPut(id: string, newTournamentDTO?: NewTournamentDTO, observe: any = 'body', reportProgress: boolean = false, options?: {httpHeaderAccept?: undefined, context?: HttpContext}): Observable<any> {
        if (id === null || id === undefined) {
            throw new Error('Required parameter id was null or undefined when calling tournamentsIdPut.');
        }

        let localVarHeaders = this.defaultHeaders;

        let localVarHttpHeaderAcceptSelected: string | undefined = options && options.httpHeaderAccept;
        if (localVarHttpHeaderAcceptSelected === undefined) {
            // to determine the Accept header
            const httpHeaderAccepts: string[] = [
            ];
            localVarHttpHeaderAcceptSelected = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        }
        if (localVarHttpHeaderAcceptSelected !== undefined) {
            localVarHeaders = localVarHeaders.set('Accept', localVarHttpHeaderAcceptSelected);
        }

        let localVarHttpContext: HttpContext | undefined = options && options.context;
        if (localVarHttpContext === undefined) {
            localVarHttpContext = new HttpContext();
        }


        // to determine the Content-Type header
        const consumes: string[] = [
            'application/json',
            'text/json',
            'application/*+json'
        ];
        const httpContentTypeSelected: string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected !== undefined) {
            localVarHeaders = localVarHeaders.set('Content-Type', httpContentTypeSelected);
        }

        let responseType_: 'text' | 'json' | 'blob' = 'json';
        if (localVarHttpHeaderAcceptSelected) {
            if (localVarHttpHeaderAcceptSelected.startsWith('text')) {
                responseType_ = 'text';
            } else if (this.configuration.isJsonMime(localVarHttpHeaderAcceptSelected)) {
                responseType_ = 'json';
            } else {
                responseType_ = 'blob';
            }
        }

        let localVarPath = `/tournaments/${this.configuration.encodeParam({name: "id", value: id, in: "path", style: "simple", explode: false, dataType: "string", dataFormat: undefined})}`;
        return this.httpClient.request<any>('put', `${this.configuration.basePath}${localVarPath}`,
            {
                context: localVarHttpContext,
                body: newTournamentDTO,
                responseType: <any>responseType_,
                withCredentials: this.configuration.withCredentials,
                headers: localVarHeaders,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * @param newTournamentDTO 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public tournamentsPost(newTournamentDTO?: NewTournamentDTO, observe?: 'body', reportProgress?: boolean, options?: {httpHeaderAccept?: undefined, context?: HttpContext}): Observable<any>;
    public tournamentsPost(newTournamentDTO?: NewTournamentDTO, observe?: 'response', reportProgress?: boolean, options?: {httpHeaderAccept?: undefined, context?: HttpContext}): Observable<HttpResponse<any>>;
    public tournamentsPost(newTournamentDTO?: NewTournamentDTO, observe?: 'events', reportProgress?: boolean, options?: {httpHeaderAccept?: undefined, context?: HttpContext}): Observable<HttpEvent<any>>;
    public tournamentsPost(newTournamentDTO?: NewTournamentDTO, observe: any = 'body', reportProgress: boolean = false, options?: {httpHeaderAccept?: undefined, context?: HttpContext}): Observable<any> {

        let localVarHeaders = this.defaultHeaders;

        let localVarHttpHeaderAcceptSelected: string | undefined = options && options.httpHeaderAccept;
        if (localVarHttpHeaderAcceptSelected === undefined) {
            // to determine the Accept header
            const httpHeaderAccepts: string[] = [
            ];
            localVarHttpHeaderAcceptSelected = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        }
        if (localVarHttpHeaderAcceptSelected !== undefined) {
            localVarHeaders = localVarHeaders.set('Accept', localVarHttpHeaderAcceptSelected);
        }

        let localVarHttpContext: HttpContext | undefined = options && options.context;
        if (localVarHttpContext === undefined) {
            localVarHttpContext = new HttpContext();
        }


        // to determine the Content-Type header
        const consumes: string[] = [
            'application/json',
            'text/json',
            'application/*+json'
        ];
        const httpContentTypeSelected: string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected !== undefined) {
            localVarHeaders = localVarHeaders.set('Content-Type', httpContentTypeSelected);
        }

        let responseType_: 'text' | 'json' | 'blob' = 'json';
        if (localVarHttpHeaderAcceptSelected) {
            if (localVarHttpHeaderAcceptSelected.startsWith('text')) {
                responseType_ = 'text';
            } else if (this.configuration.isJsonMime(localVarHttpHeaderAcceptSelected)) {
                responseType_ = 'json';
            } else {
                responseType_ = 'blob';
            }
        }

        let localVarPath = `/tournaments`;
        return this.httpClient.request<any>('post', `${this.configuration.basePath}${localVarPath}`,
            {
                context: localVarHttpContext,
                body: newTournamentDTO,
                responseType: <any>responseType_,
                withCredentials: this.configuration.withCredentials,
                headers: localVarHeaders,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public tournamentsTeamsGet(observe?: 'body', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<Array<TeamForTournamentDTO>>;
    public tournamentsTeamsGet(observe?: 'response', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpResponse<Array<TeamForTournamentDTO>>>;
    public tournamentsTeamsGet(observe?: 'events', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpEvent<Array<TeamForTournamentDTO>>>;
    public tournamentsTeamsGet(observe: any = 'body', reportProgress: boolean = false, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<any> {

        let localVarHeaders = this.defaultHeaders;

        let localVarHttpHeaderAcceptSelected: string | undefined = options && options.httpHeaderAccept;
        if (localVarHttpHeaderAcceptSelected === undefined) {
            // to determine the Accept header
            const httpHeaderAccepts: string[] = [
                'text/plain',
                'application/json',
                'text/json'
            ];
            localVarHttpHeaderAcceptSelected = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        }
        if (localVarHttpHeaderAcceptSelected !== undefined) {
            localVarHeaders = localVarHeaders.set('Accept', localVarHttpHeaderAcceptSelected);
        }

        let localVarHttpContext: HttpContext | undefined = options && options.context;
        if (localVarHttpContext === undefined) {
            localVarHttpContext = new HttpContext();
        }


        let responseType_: 'text' | 'json' | 'blob' = 'json';
        if (localVarHttpHeaderAcceptSelected) {
            if (localVarHttpHeaderAcceptSelected.startsWith('text')) {
                responseType_ = 'text';
            } else if (this.configuration.isJsonMime(localVarHttpHeaderAcceptSelected)) {
                responseType_ = 'json';
            } else {
                responseType_ = 'blob';
            }
        }

        let localVarPath = `/tournaments/teams`;
        return this.httpClient.request<Array<TeamForTournamentDTO>>('get', `${this.configuration.basePath}${localVarPath}`,
            {
                context: localVarHttpContext,
                responseType: <any>responseType_,
                withCredentials: this.configuration.withCredentials,
                headers: localVarHeaders,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * @param id 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public tournamentsTournamentmanagerIdGet(id: string, observe?: 'body', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<Array<TournamentForManagerDTO>>;
    public tournamentsTournamentmanagerIdGet(id: string, observe?: 'response', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpResponse<Array<TournamentForManagerDTO>>>;
    public tournamentsTournamentmanagerIdGet(id: string, observe?: 'events', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpEvent<Array<TournamentForManagerDTO>>>;
    public tournamentsTournamentmanagerIdGet(id: string, observe: any = 'body', reportProgress: boolean = false, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<any> {
        if (id === null || id === undefined) {
            throw new Error('Required parameter id was null or undefined when calling tournamentsTournamentmanagerIdGet.');
        }

        let localVarHeaders = this.defaultHeaders;

        let localVarHttpHeaderAcceptSelected: string | undefined = options && options.httpHeaderAccept;
        if (localVarHttpHeaderAcceptSelected === undefined) {
            // to determine the Accept header
            const httpHeaderAccepts: string[] = [
                'text/plain',
                'application/json',
                'text/json'
            ];
            localVarHttpHeaderAcceptSelected = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        }
        if (localVarHttpHeaderAcceptSelected !== undefined) {
            localVarHeaders = localVarHeaders.set('Accept', localVarHttpHeaderAcceptSelected);
        }

        let localVarHttpContext: HttpContext | undefined = options && options.context;
        if (localVarHttpContext === undefined) {
            localVarHttpContext = new HttpContext();
        }


        let responseType_: 'text' | 'json' | 'blob' = 'json';
        if (localVarHttpHeaderAcceptSelected) {
            if (localVarHttpHeaderAcceptSelected.startsWith('text')) {
                responseType_ = 'text';
            } else if (this.configuration.isJsonMime(localVarHttpHeaderAcceptSelected)) {
                responseType_ = 'json';
            } else {
                responseType_ = 'blob';
            }
        }

        let localVarPath = `/tournaments/tournamentmanager/${this.configuration.encodeParam({name: "id", value: id, in: "path", style: "simple", explode: false, dataType: "string", dataFormat: undefined})}`;
        return this.httpClient.request<Array<TournamentForManagerDTO>>('get', `${this.configuration.basePath}${localVarPath}`,
            {
                context: localVarHttpContext,
                responseType: <any>responseType_,
                withCredentials: this.configuration.withCredentials,
                headers: localVarHeaders,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

}
