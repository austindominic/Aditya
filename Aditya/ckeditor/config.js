/**
 * @license Copyright (c) 2003-2016, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.allowedContent = true;
    
    config.protectedSource.push(/<i[^>]*><\/i>/g);
    // ALLOW <i></i>

    config.protectedSource.push(/<i[^>]*><\/i>/g);
    // ALLOW <span></span>

    config.protectedSource.push(/<span[^>]*><\/span>/g);
 

    config.protectedSource.push(/<\?[\s\S]*?\?>/g);
    config.enterMode = CKEDITOR.ENTER_BR;
   

};
