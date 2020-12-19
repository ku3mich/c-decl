parser grammar ClangParser;

options { 
    tokenVocab=ClangLexer; 
    superClass=Antlr4.Parser; 
}

declaratorList: declarator (WS* COMMA WS* declarator)*;
declarationList: declaration (WS* COMMA WS* declaration)*;

declarationMix: declaration | declarator;
declarationMixList: declarationMix (WS* COMMA WS* declarationMix)*;

codeBlock: LC RC;
array:LB RB;

identifier:
	IDENTIFIER;

type: 
	identifier;

declarator:
	WS declarator? 
	| IDENTIFIER declarator? 
	| PTR declarator? 
	| LP declarator? RP declarator?
	| LP declarationMixList? RP 
	| declarator LB RB declarator?
	| array
	| codeBlock
	;
	
declaration:
	type WS* declarator?;

typeDefVariants: 
	declaration (WS* identifier)?
	| type WS* declaratorList;

typedef:
	TYPEDEF WS* typeDefVariants SC;

block
	: declaration 
	| typedef
	;

file: block* EOF;
    