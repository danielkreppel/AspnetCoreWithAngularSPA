import { ErrorHandler, Injectable, Injector, Inject } from '@angular/core';

@Injectable()
export class GlobalErrorHandler extends ErrorHandler {

    constructor(
        @Inject(Injector) private readonly injector: Injector
    ) {
        super();
    }

    handleError(error) {
        console.log("Handling global error: " + error);        
        
        super.handleError(error);
    }

 

}