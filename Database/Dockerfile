# using vNext image
FROM microsoft/mssql-server-linux:2017-latest

# set environment variables
ENV SA_PASSWORD=Pass@word
ENV ACCEPT_EULA=Y

COPY entrypoint.sh entrypoint.sh
COPY SqlCmdStartup.sh SqlCmdStartup.sh
COPY SqlCmdScript.sql SqlCmdScript.sql

# Grant permissions for the SqlCmdStartup.sh script to be executable
RUN chmod +x ./SqlCmdStartup.sh
#start everything
CMD /bin/bash ./entrypoint.sh