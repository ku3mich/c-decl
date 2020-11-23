lexer grammar ClangLexer;

import UniCase, CrLf, Symbols;

TYPEDEF:  T Y P E D E F;

LP: S_L_PAREN;
RP: S_R_PAREN;
PTR: S_ASTERISK;
COMMA: S_COMMA;
WS: [ \t];
EOL: CR? LF;
LB: S_L_BRACKET;
RB: S_R_BRACKET;
LC: S_L_BRACE;
RC: S_R_BRACE;

SC: S_SEMI_COLON;

IDENTIFIER: [_A-Za-z] [_A-Za-z0-9]*;
